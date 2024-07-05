using MultiPartFormData.Structures;
using System.Text;

namespace MultiPartUnitTests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(@"-----------------------------41952539122868
Content-Disposition: form-data; name=""username""

example
-----------------------------41952539122868
Content-Disposition: form-data; name=""email""

example@data.com
-----------------------------41952539122868
Content-Disposition: form-data; name=""files[]""; filename=""photo1.jpg""
Content-Type: image/jpeg

ExampleBinaryData012031203
-----------------------------41952539122868--", "---------------------------41952539122868","utf-8")]
        [InlineData(@"-----------------------------41952539122868
Content-Disposition: form-data; name=""username""

example
-----------------------------41952539122868
Content-Disposition: form-data; name=""email""

example@data.com
-----------------------------41952539122868
Content-Disposition: form-data; name=""files[]""; filename=""photo1.jpg""
Content-Type: image/jpeg

ExampleBinaryData012031203
-----------------------------41952539122868--", "", "")]
        public void TestParser(string Data, string boundary, string encoding)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(Data);

            MultiPartParser parser = new();

            parser.Parse_MultiPartFormData(bytes, boundary, out List<PartContent> parts, out bool success, out string ErrorMessage, encoding);

            Assert.True(success);
            Assert.True(parts.Count>0);

        }
    }
}