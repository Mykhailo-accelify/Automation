using API.Converters;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipTypeInfrastructure
{
    [JsonConverter(typeof(ConverterINamed))]
    public INamed TypeInfrastructure { get; set; }

}