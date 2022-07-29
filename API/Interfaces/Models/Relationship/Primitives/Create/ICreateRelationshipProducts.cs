using API.Converters;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipProducts
{
    [JsonConverter(typeof(ConverterINamed))]
    public ICollection<INamed>? Products { get; set; }

}