using API.Converters;
using API.Interfaces.Models.Primitives;
using API.Models.Lonely;
using API.Models.Shallow.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipClients
{
    [JsonConverter(typeof(InterfaceConverter<LonelyClient, ILonelyClient>))]
    public ICollection<ILonelyClient> Clients { get; set; }

}