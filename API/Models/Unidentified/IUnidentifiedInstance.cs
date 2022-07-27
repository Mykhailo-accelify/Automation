using API.Models.Shallow.Primitives;
using API.Models.Shallow.Relationship;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow;

public interface IUnidentifiedInstance : IInstanceColumns, IInstanceShallowRelationship
{
    
}