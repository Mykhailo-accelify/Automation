using API.Interfaces.Models.Relationship.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Create;

public class CreateState : IStateColumns, ICreateStateRelationships
{
    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public ICollection<INamed> Clients { get; set; }

}