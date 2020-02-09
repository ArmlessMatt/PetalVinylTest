using System.Net;

namespace Common.Infrastructure.Models
{
    public class HttpResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public T Content { get; set; }
    }
}
