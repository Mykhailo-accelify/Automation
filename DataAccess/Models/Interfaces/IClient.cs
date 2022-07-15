using DataAccess.Models.Interfaces.Primitives;
using DataAccess.Models.Interfaces.Relationships;

namespace DataAccess.Models.Interfaces;

public interface IClient : IIdentified, INamed, IAbbreviated, IClientRelationships
{
    public int AmountStudents { get; set; }
    
}