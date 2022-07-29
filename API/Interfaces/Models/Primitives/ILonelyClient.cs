using API.Converters;
using API.Models.Lonely;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Primitives;

[JsonConverter(typeof(InterfaceConverter<LonelyClient, ILonelyClient>))]
public interface ILonelyClient : IIdentified, IClientColumns
{
    
}