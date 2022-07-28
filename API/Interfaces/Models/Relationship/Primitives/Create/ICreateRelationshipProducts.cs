using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipProducts
{
    public ICollection<INamed>? Products { get; set; }

}