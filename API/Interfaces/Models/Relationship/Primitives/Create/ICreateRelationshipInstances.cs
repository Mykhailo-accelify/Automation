using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipInstances
{
    public ICollection<INamed> Instances { get; set; }

}