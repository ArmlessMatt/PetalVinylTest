using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Interfaces;
using Common.Infrastructure.Models;
using Common.Infrastructure.Models.Common;
using Vinyl.Data.Constants;
using Vinyl.Data.Models.Discogs;
using Vinyl.Domain.Interfaces;
using Vinyl.Domain.Models;

namespace Vinyl.Data.Services
{
    public class DiscogsVinylDataService : IVinylDataService
    {
        private IHttpClient httpClient;

        public DiscogsVinylDataService(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public ServiceResponse<int> GetTotalVinyls()
        {
            var queryParam = new QueryParameter
            {
                Name = DiscogsConstants.PER_PAGE_QUERY_PARAM_NAME,
                Value = "1"
            };
            var httpResult = httpClient.Get<DiscogsResponse>(DiscogsConstants.URL, DiscogsConstants.PATH_TO_COLLECTION,
                    new List<QueryParameter> { queryParam }).Result;

            if (httpResult.Status == HttpStatusCode.OK)
            {
                return new SuccesResponse<int>(httpResult.Content.PaginationInfo.NumberOfElements);
            }
            return new ErrorResponse<int>(new List<string> { DiscogsConstants.ERROR_MESSAGE_DISCOGS_CALL_FAILED });
        }

        public async Task<ServiceResponse<List<Domain.Models.Vinyl>>> GetVinylsByIndex(List<int> indexList)
        {
            var perPageQueryParam = new QueryParameter
            {
                Name = DiscogsConstants.PER_PAGE_QUERY_PARAM_NAME,
                Value = "1"
            };

            var responseTaskList = new List<Task<HttpResponse<DiscogsResponse>>>();
            foreach (var index in indexList)
            {
                var newTask = httpClient.Get<DiscogsResponse>(DiscogsConstants.URL, DiscogsConstants.PATH_TO_COLLECTION,
                    new List<QueryParameter> { perPageQueryParam, CreatePageQueryParam(index) });
                responseTaskList.Add(newTask);
            }

            var completedHttpTask = await Task.WhenAll(responseTaskList);

            if (completedHttpTask.All(result => result.Status == HttpStatusCode.OK))
            {
                var vinylsList = new List<Domain.Models.Vinyl>();
                foreach (var httpResult in completedHttpTask)
                {
                    vinylsList.AddRange(GetVinylsListFromDiscogsResponse(httpResult.Content));
                }
                return new SuccesResponse<List<Domain.Models.Vinyl>>(vinylsList);
            }
            return new ErrorResponse<List<Domain.Models.Vinyl>>(new List<string> { DiscogsConstants.ERROR_MESSAGE_DISCOGS_CALL_FAILED });
        }

        private List<Domain.Models.Vinyl> GetVinylsListFromDiscogsResponse(DiscogsResponse response)
        {
            var vinylList = new List<Domain.Models.Vinyl>();
            foreach (var vinyl in response.Releases)
            {
                var convertedVinyl = new Domain.Models.Vinyl
                {
                    Title = vinyl.BasicInformation.Title
                };
                convertedVinyl.Artists.AddRange(vinyl.BasicInformation.Artists.Select(artist => artist.Name));
                vinylList.Add(convertedVinyl);
            }
            return vinylList;
        }

        private QueryParameter CreatePageQueryParam(int page)
        {
            return new QueryParameter
            {
                Name = DiscogsConstants.PAGE_QUERY_PARAM_NAME,
                Value = page.ToString()
            };
        }
    }
}
