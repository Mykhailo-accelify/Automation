using API.Converters;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipTypeInstance
{
    [JsonConverter(typeof(ConverterINamed))]
    public INamed TypeInstance { get; set; }

}