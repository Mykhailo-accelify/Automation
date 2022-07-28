using API.Interfaces.Models.Relationship.Primitives.Shallow;
using API.Models.Shallow.Primitives;

namespace API.Models.Shallow;

public class ShallowState : ILonelyState, IShallowRelationshipClients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public ICollection<ILonelyClient> Clients { get; set; }
}