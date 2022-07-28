using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public class ShallowTypeInfrastructure : IType, IShallowRelationshipInfrastructures
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }
}