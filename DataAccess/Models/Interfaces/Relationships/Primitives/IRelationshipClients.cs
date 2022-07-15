using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipClients
{
    public ICollection<Client> Clients { get; set; }

}