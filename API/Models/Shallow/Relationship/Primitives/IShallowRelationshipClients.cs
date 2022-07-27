using API.Models.Shallow.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipClients
{
    public ICollection<ILonelyClient> Clients { get; set; }

}