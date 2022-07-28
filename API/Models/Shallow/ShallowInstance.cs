using API.Interfaces.Models.Relationship.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public class ShallowInstance : ILonelyInstance, IInstanceShallowRelationship
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Endpoint { get; set; }
    public string Secret { get; set; }
    public int TypeInstanceId { get; set; }
    public IType TypeInstance { get; set; }
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }
}