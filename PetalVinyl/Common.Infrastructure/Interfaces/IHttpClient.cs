using Common.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Infrastructure.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponse<T>> Get<T>(string url, string path, List<QueryParameter> queryParameters);
    }
}
