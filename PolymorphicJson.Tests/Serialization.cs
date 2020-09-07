using FluentAssertions;
using NUnit.Framework;
using PolymorphicJson.Model;
using System.Threading.Tasks;

namespace PolymorphicJson.Tests
{
    public class Serialization
    {
        [Test]
        public async Task SerializesOnlyPropertiesOfBaseType()
        {
            var request = new MessageWithBaseType
            {
                Type = "A",
                Payload = new PayloadA
                {
                    Text = "content"
                }
            };
            var expected = await FileLoader.LoadJson("MissingProperties.json");

            var json = Serializer.Serialize(request);

            json.Should().Be(expected);
        }

        [Test]
        public async Task SerializesAllPropertiesOfObject()
        {
            object request = new MessageWithObject
            {
                Type = "A",
                Payload = new PayloadA
                {
                    Text = "content"
                }
            };
            var expected = await FileLoader.LoadJson("Complete.json");

            var json = Serializer.Serialize(request);

            json.Should().Be(expected);
        }
    }
}