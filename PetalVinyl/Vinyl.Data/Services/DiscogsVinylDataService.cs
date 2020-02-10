using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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

        public ServiceResponse<List<Domain.Models.Vinyl>> GetVinylsByIndex(List<int> indexList)
        {
            throw new NotImplementedException();
        }
    }
}
