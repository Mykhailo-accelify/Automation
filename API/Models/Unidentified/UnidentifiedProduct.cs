using API.Interfaces.Models.Primitives;
using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Unidentified;

public class UnidentifiedProduct : IProductColumns, IShallowRelationshipClients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ILonelyClient> Clients { get; set; }
}