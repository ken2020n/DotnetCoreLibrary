using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApiBase.JsonConverters
{
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        private const string CustomFormat = "yyyy-MM-dd HH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), CustomFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CustomFormat));
        }
    }
}