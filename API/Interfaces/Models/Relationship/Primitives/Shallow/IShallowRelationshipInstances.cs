using API.Converters;
using API.Models.Lonely;
using API.Models.Shallow.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipInstances
{
    [JsonConverter(typeof(InterfaceConverter<LonelyInstance, ILonelyInstance>))]
    public ICollection<ILonelyInstance> Instances { get; set; }

}