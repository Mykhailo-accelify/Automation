using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipInfrastructures
{
    public ICollection<INamed> Infrastructures { get; set; }

}