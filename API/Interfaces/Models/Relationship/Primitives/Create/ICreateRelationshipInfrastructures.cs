using API.Converters;
using API.Models.Create.Primitives;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;
namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipInfrastructures
{
    [JsonConverter(typeof(InterfaceConverter<Named, INamed>))]
    public ICollection<INamed> Infrastructures { get; set; }

}