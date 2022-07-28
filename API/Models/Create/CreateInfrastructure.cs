using API.Interfaces.Models.Relationship.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Create;

public class CreateInfrastructure : IInfrastructureColumns, ICreateInfrastructureRelationships
{
    public string Name { get; set; }

    public int MaxStudents { get; set; }

    public string ConfigurationFolder { get; set; }

    public INamed TypeInfrastructure { get; set; }

    public ICollection<INamed> Clients { get; set; }

    public ICollection<INamed> Instances { get; set; }

    public ICollection<INamed> InfrastructureVariables { get; set; }

}