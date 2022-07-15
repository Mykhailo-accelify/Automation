using DataAccess.Models.Interfaces.Primitives;
using DataAccess.Models.Interfaces.Relationships;

namespace DataAccess.Models.Interfaces;

public interface IInstance : IIdentified, INamed, IInstanceRelationships
{
    public string Endpoint { get; set; }

    public string Secret { get; set; }
    
}