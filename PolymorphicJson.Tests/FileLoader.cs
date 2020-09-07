using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace PolymorphicJson.Tests
{
    internal static class FileLoader
    {
        public static async Task<string> LoadJson(string filename)
        {
            var path = Path.Combine(
                TestContext.CurrentContext.TestDirectory, 
                "Json", 
                filename);
            return await File.ReadAllTextAsync(Path.Combine(path));
        }
    }
}
