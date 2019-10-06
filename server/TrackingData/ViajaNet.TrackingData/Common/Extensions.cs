using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace ViajaNet.TrackingData.Common
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            if (obj == null) return string.Empty;
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        public static T FromJson<T>(this string str) => JsonConvert.DeserializeObject<T>(str);
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> callback)
        {
            foreach (var item in enumerable) callback(item);
        }
        public static int ToInt32(this object obj)
        {
            Int32.TryParse(obj?.ToString(), out int result);
            return result;
        }
    }
}
