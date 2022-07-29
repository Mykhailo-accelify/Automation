using API.Converters;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;
namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipInfrastructures
{
    [JsonConverter(typeof(ConverterINamed))]
    public ICollection<INamed> Infrastructures { get; set; }

}