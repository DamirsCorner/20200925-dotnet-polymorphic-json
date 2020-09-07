using FluentAssertions;
using NUnit.Framework;
using PolymorphicJson.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace PolymorphicJson.Tests
{
    public class Deserialization
    {
        [Test]
        public async Task DeserializesJsonElementIntoObject()
        {
            var json = await FileLoader.LoadJson("Complete.json");

            var value = Serializer.Deserialize<MessageWithObject>(json);

            value.Payload.Should().BeOfType<JsonElement>();
        }

        [Test]
        public async Task DeserializesBaseTypeIntoBaseType()
        {
            var json = await FileLoader.LoadJson("Complete.json");
            var expected = new MessageWithBaseType
            {
                Type = "A",
                Payload = new Payload()
            };

            var value = Serializer.Deserialize<MessageWithBaseType>(json);

            value.Should().BeEquivalentTo(
                expected, 
                options => options.RespectingRuntimeTypes());
        }

        [Test]
        public async Task DeserializesDeclaredTypeIntoGeneric()
        {
            var json = await FileLoader.LoadJson("Complete.json");
            var expected = new MessageWithBaseType
            {
                Type = "A",
                Payload = new PayloadA
                {
                    Text = "content"
                }
            };

            var value = Serializer.Deserialize<MessageGeneric<PayloadA>>(json);
            
            value.Should().BeEquivalentTo(
                expected, 
                options => options.RespectingRuntimeTypes());
        }

        [Test]
        public async Task DeserializesRecognizedTypeIntoGeneric()
        {
            var json = await FileLoader.LoadJson("Complete.json");
            var expected = new MessageWithBaseType
            {
                Type = "A",
                Payload = new PayloadA
                {
                    Text = "content"
                }
            };

            var value = Serializer.Deserialize(json);
            
            value.Should().BeEquivalentTo(
                expected, 
                options => options.RespectingRuntimeTypes());
        }
    }
}
