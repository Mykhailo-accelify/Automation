using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public class ShallowInfrastructureVariable : IKeyValue, IShallowRelationshipInfrastructures
{
    public string Name { get; set; }
    public string Value { get; set; }
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }
}