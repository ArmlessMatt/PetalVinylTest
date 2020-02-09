namespace Common.Infrastructure.Models.Common
{
    public class SuccesResponse<T> : ServiceResponse<T>
    {
        public SuccesResponse(T response)
        {
            Response = response;
            IsSucces = true;
        }
    }
}
