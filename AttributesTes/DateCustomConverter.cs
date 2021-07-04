using Newtonsoft.Json;
using System;

namespace AttributesTes
{
    internal class DateCustomConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yy-MMM-d"));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType,  DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}