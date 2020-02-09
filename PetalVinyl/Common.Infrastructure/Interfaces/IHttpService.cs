using Common.Infrastructure.Models;

namespace Common.Infrastructure.Interfaces
{
    interface IHttpService
    {
        HttpResponse<T> Get<T>(string url, string path, QueryParameter[] queryParameters);
    }
}
