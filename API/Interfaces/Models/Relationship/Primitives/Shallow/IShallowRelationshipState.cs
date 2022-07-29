using API.Converters;
using API.Models.Lonely;
using API.Models.Shallow.Primitives;
using Newtonsoft.Json;
namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipState
{
    [JsonConverter(typeof(InterfaceConverter<LonelyState, ILonelyState>))]
    public ILonelyState State { get; set; }

}