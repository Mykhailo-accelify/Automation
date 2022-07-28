using API.Models.Shallow.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipClients
{
    public ICollection<ILonelyClient> Clients { get; set; }

}