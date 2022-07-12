using API.Interfaces;

namespace API.Models
{
    public class Response<Type> : IResponse<Type>
    {
        public Response(Exception? error)
        {
            Error = error;
        }

        public Response(Type? result)
        {
            isSuccess = true;
            Result = result;
        }

        public bool isSuccess { get; set; }

        public Type? Result { get; set; }

        public Exception? Error { get; set; }        
    }
}
