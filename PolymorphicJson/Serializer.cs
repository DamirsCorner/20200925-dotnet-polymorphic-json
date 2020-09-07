using PolymorphicJson.Model;
using System.Text.Json;

namespace PolymorphicJson
{
    public static class Serializer
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static string Serialize<TValue>(TValue value)
        {
            return JsonSerializer.Serialize(value, options);
        }

        public static TValue Deserialize<TValue>(string json)
        {
            return JsonSerializer.Deserialize<TValue>(json, options);
        }

        public static IMessageGeneric<Payload> Deserialize(string json)
        {
            var jsonDocument = JsonDocument.Parse(json);
            var typeValue = jsonDocument.RootElement.GetProperty("type").GetString();

            switch (typeValue)
            {
                case "A":
                    return Deserialize<MessageGeneric<PayloadA>>(json);
                case "B":
                    return Deserialize<MessageGeneric<PayloadB>>(json);
                default:
                    return Deserialize<MessageGeneric<Payload>>(json);
            }
        }
    }
}
