using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public class ShallowTypeInstance : IType, IShallowRelationshipInstances
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ILonelyInstance> Instances { get; set; }
}