namespace DataAccess.Models.Interfaces.Primitives;

public interface IInstanceColumns : INamed
{
    public string Endpoint { get; set; }

    public string Secret { get; set; }

    public int TypeInstanceId { get; set; }

}