using API.Converters;
using API.Interfaces.Models.Primitives;
using API.Interfaces.Models.Relationship.Shallow;
using API.Models.Shallow;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Shallow;

//[JsonConverter(typeof(InterfaceConverter<ShallowClient, IShallowClient>))]
public interface IShallowClient : ILonelyClient, IClientShallowRelationship
{
    
}