using Newtonsoft.Json;
using System;

namespace Lesson8.Models
{
    internal class CustomDateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null && reader.Value is long)
            {
                return new DateTime(1970, 1, 1).AddSeconds((long)reader.Value);
            }

            if (reader.Value != null && reader.Value is string)
            {
                var strDate = (string)reader.Value;
                if (DateTime.TryParseExact(strDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    return dt;
                }

                if (DateTime.TryParseExact(strDate, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out DateTime dt1))
                {
                    return dt1;
                }
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}