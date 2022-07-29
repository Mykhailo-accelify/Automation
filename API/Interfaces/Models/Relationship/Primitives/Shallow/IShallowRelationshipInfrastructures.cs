using API.Converters;
using API.Models.Lonely;
using API.Models.Shallow.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipInfrastructures
{
    [JsonConverter(typeof(InterfaceConverter<LonelyInfrastructure, ILonelyInfrastructure>))]
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }

}