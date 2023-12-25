using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shopfloor.Core.Extensions.Objects
{
    public static class JsonExtension
    {
        public static T GetJsonValueByKey<T>(this object data, string field)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var jsonObject = JObject.Parse(json);
            var value = jsonObject.Value<T>(field);
            if (value == null) value = jsonObject.Value<T>(field.FirstCharToLowerCase());
            return value;
        }
        public static string ToJson(this object value)
        {
            var s = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return s;
        }
    }
}
