using API.Converters;
using API.Models.Create.Primitives;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipTypeInstance
{
    [JsonConverter(typeof(InterfaceConverter<Named, INamed>))]
    public INamed TypeInstance { get; set; }

}