using API.Models.Shallow.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipInfrastructures
{
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }

}