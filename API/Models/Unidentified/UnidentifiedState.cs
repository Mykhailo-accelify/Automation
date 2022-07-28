using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public class UnidentifiedState : IStateColumns, IShallowRelationshipClients
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public ICollection<ILonelyClient> Clients { get; set; }
}