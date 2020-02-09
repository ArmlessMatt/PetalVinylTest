using System.Collections.Generic;

namespace Common.Infrastructure.Models.Common
{
    public abstract class ServiceResponse<T> 
    {
        public T Response { get; protected set; }
        public bool IsSucces { get; protected set; }
        public List<string> ErrorMessages { get; private set; }

        public ServiceResponse()
        {
            ErrorMessages = new List<string>();
        }
    }
}
