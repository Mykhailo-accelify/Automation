using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipClients
{
    public ICollection<INamed> Clients { get; set; }

}