using API.Converters;
using DataAccess.Entities;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipInfrastructureVariables
{
    [JsonConverter(typeof(InterfaceConverter<APIConstant, IKeyValue>))]
    public ICollection<IKeyValue> InfrastructureVariables { get; set; }

}