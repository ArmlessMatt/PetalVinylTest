using Common.Infrastructure.Models;

namespace Common.Infrastructure.Interfaces
{
    public interface IHttpClient
    {
        HttpResponse<T> Get<T>(string url, string path, QueryParameter[] queryParameters);
    }
}
