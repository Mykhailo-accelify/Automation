using API.Models.Create.Primitives;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Converters;
public class ProductConverter : JsonConverter
{
    public override bool CanConvert(Type typeToConvert)
    {
        return true;
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var json = JToken.ReadFrom(reader);
        if (objectType == typeof(ICollection<INamed>))
        {
            var list = json.ToObject<ICollection<Named>>();

            return list as ICollection<INamed>;
        }

        var typeToken = json.SelectToken("name"); // or ??json.SelectToken("Type");
        if (typeToken == null) return null;
        var named = json.ToObject<Named>();

        //MethodInfo mi = typeof(JToken)
        //    .GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //    .Where(m => m.Name == "ToObject" && m.GetParameters().Length == 0 && m.IsGenericMethod)
        //    .FirstOrDefault()
        //    ?.MakeGenericMethod(locationType);
        //var location = mi?.Invoke(json, null);
        //return (ILocation)location;

        //var named = DeserializeLocationRuntime(json, typeof(Named));
        //var type = ResolveILocationTypeRuntime((int)typeToken);
        return named;
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

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var product = value as INamed;
        serializer.Serialize(writer, product, typeof(Named));
    }
}