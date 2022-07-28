using API.Interfaces.Models.Relationship.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public class UnidentifiedInfrastructure : IInfrastructureColumns, IInfrastructureShallowRelationship
{
    public string Name { get; set; }
    public int MaxStudents { get; set; }
    public string ConfigurationFolder { get; set; }
    public int TypeInfrastructureId { get; set; }
    public IType TypeInfrastructure { get; set; }
    public ICollection<ILonelyClient> Clients { get; set; }
    public ICollection<ILonelyInstance> Instances { get; set; }
    public ICollection<IKeyValue> InfrastructureVariables { get; set; }
}