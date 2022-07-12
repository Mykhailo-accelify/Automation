
namespace API.Interfaces
{
    public interface IResponse<Type>
    {
        Exception? Error { get; set; }
        bool isSuccess { get; set; }
        Type? Result { get; set; }
    }
}