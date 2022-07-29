using API.Converters;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipClients
{
    [JsonConverter(typeof(ConverterINamed))]
    public ICollection<INamed> Clients { get; set; }

}