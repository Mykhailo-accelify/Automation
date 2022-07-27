namespace DataAccess.Models.Interfaces.Primitives;

public interface IInfrastructureColumns : INamed
{
    public int MaxStudents { get; set; }

    public string ConfigurationFolder { get; set; }

    public int TypeInfrastructureId { get; set; }

}