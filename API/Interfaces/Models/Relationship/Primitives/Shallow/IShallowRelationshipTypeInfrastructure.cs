using API.Converters;
using API.Models.Lonely;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipTypeInfrastructure
{
    [JsonConverter(typeof(InterfaceConverter<LonelyType, IType>))]
    public IType TypeInfrastructure { get; set; }

}