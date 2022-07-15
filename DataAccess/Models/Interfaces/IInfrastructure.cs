using DataAccess.Models.Interfaces.Primitives;
using DataAccess.Models.Interfaces.Relationships;

namespace DataAccess.Models.Interfaces;

public interface IInfrastructure : IIdentified, INamed, IInfrastructureRelationships
{

    public int MaxStudents { get; set; }

    public string ConfigurationFolder { get; set; }


}