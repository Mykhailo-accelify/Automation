using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipState
{

    public int StateId { get; set; }

    public State State { get; set; }

}