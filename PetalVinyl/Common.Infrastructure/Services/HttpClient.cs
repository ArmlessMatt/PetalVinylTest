
using Common.Infrastructure.Interfaces;
using Common.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Infrastructure.Services
{
    public class HttpClient : IHttpClient
    {
        private IHttpClientFactory httpFactory;

        public HttpClient(IHttpClientFactory clientFactory)
        {
            httpFactory = clientFactory;
        }

        public async Task<HttpResponse<T>> Get<T>(string url, string path, List<QueryParameter> queryParameters)
        {
            var fullUrl = url + path;
            if (queryParameters != null)
            {
                var stringParamsList = queryParameters.Select(queryParam => queryParam.ToString());
                fullUrl += string.Join("&", stringParamsList);
            }
            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);

            var client = httpFactory.CreateClient();
            var httpResponse = await client.SendAsync(request);

            var clientResponse = new HttpResponse<T>();
            var responseStream = await httpResponse.Content.ReadAsStreamAsync();
            clientResponse.Status = httpResponse.StatusCode;
            clientResponse.Content = JsonConvert.DeserializeObject<T>(responseStream.ToString());

            return clientResponse;
        }
    }
}
