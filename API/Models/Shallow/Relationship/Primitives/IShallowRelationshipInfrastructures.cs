using API.Models.Shallow.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipInfrastructures
{
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }

}