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
    }
}
