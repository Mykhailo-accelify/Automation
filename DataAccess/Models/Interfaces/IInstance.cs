using DataAccess.Models.Interfaces.Primitives;
using DataAccess.Models.Interfaces.Relationships;

namespace DataAccess.Models.Interfaces;

public interface IInstance : IIdentified, IInstanceColumns, IInstanceRelationships
{
    
}