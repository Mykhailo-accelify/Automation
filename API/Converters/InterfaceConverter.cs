using API.Models.Create.Primitives;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Converters;
public class InterfaceConverter<TClass, TInterface> : 
    JsonConverter
    where TClass : class, TInterface, new()
{
    public override bool CanConvert(Type typeToConvert)
    {
        return true;
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var json = JToken.ReadFrom(reader);
        if (objectType == typeof(ICollection<TInterface>))
        {
            var collection = json.ToObject<ICollection<TClass>>();
            return collection?.ToList<TInterface>();
        }

        if (objectType == typeof(TInterface))
        {
            var typeToken = json.SelectToken("name"); // or ??json.SelectToken("Type");
            if (typeToken == null) return null;

            var named = json.ToObject<TClass>();
            return named;
        }

        return null;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var type = value.GetType();
        if (typeof(IEnumerable<TInterface>).IsAssignableFrom(type))
        {
            var collection = (IEnumerable<TInterface>)value;
            serializer.Serialize(writer, collection, typeof(TClass));
        }

        if (type == typeof(TClass))
        {
            var model = (TInterface)value;
            serializer.Serialize(writer, model, typeof(TClass));
        }
    }

    //private Type ResolveILocationTypeRuntime(int type)
    //{
    //    switch (type)
    //    {
    //        case 1:
    //            return typeof(StreetLocation);
    //        case 2:
    //            return typeof(GeoCoordinateLocation);
    //        default:
    //            throw new ArgumentOutOfRangeException("type should be 1|2");
    //    }
    //}
    //private ILocation DeserializeLocationRuntime(JToken json, Type locationType)
    //{
    //    MethodInfo mi = typeof(JToken)
    //        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
    //        .Where(m => m.Name == "ToObject" && m.GetParameters().Length == 0 && m.IsGenericMethod)
    //        .FirstOrDefault()
    //        ?.MakeGenericMethod(locationType);
    //    var location = mi?.Invoke(json, null);
    //    return (ILocation)location;
    //}
}