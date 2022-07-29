using API.Interfaces.Models.Primitives;
using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;

namespace API.Models.Shallow;

public class ShallowProduct : ILonelyProduct, IShallowRelationshipClients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ILonelyClient> Clients { get; set; }
}