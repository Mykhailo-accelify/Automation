using API.Converters;
using API.Models.Lonely;
using API.Models.Shallow.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipProducts
{
    [JsonConverter(typeof(InterfaceConverter<LonelyProduct, ILonelyProduct>))]
    public ICollection<ILonelyProduct> Products { get; set; }

}