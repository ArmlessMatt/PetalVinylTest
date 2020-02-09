using System.Collections.Generic;

namespace Common.Infrastructure.Models.Common
{
    public class ErrorResponse<T> : ServiceResponse<T>
    {
        public ErrorResponse(List<string> errorMessages)
        {
            if (errorMessages == null) return;
            ErrorMessages.AddRange(errorMessages);
        }
    }
}
