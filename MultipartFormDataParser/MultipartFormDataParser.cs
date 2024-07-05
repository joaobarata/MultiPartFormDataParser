using MultiPartFormData.Structures;
using HttpMultipartParser;
using System.Text;

namespace MultiPartFormData
{
    public class MultiPartParser : IMultipartFormDataParser
    {
        public void Parse_MultiPartFormData(byte[] MultipartBinary, string Boundary, out List<PartContent> PartContentList, out bool Success, out string ErrorMessage, string FileEncoding = "utf-8")
        {
            Encoding encoding;
            // Switch to correct file encoding, defaults to UTF-8
            switch (FileEncoding.ToLower())
            {
                case "ascii":
                    encoding = Encoding.ASCII;
                    break;
                case "unicode":
                    encoding = Encoding.Unicode;
                    break;
                case "utf-8":
                default:
                    encoding = Encoding.UTF8;
                    break;
            }
            PartContentList = new List<PartContent>();
            try
            {
            
                MultipartFormDataParser parser;
                if (Boundary == "")
                {
                    parser = MultipartFormDataParser.Parse(new MemoryStream(MultipartBinary), encoding);
                }
                // else use the boundary provided. 
                //The library doesn't handle double quotes correctly in the boundary string so we strip the boundary of double-quotes since they are not actually used in the multipart/form data content
                else
                {
                    parser = MultipartFormDataParser.Parse(new MemoryStream(MultipartBinary), Boundary.Replace("\"", ""), encoding);
                }


                PartContent record = new ();

                // fetch all text elements and add them to the list
                foreach (ParameterPart param in parser.Parameters)
                {
                    record = new(param.Name, param.Data);

                    PartContentList.Add(record);
                }

                //fetch all the file elements and add them to the list
                foreach (FilePart filepart in parser.Files)
                {
                    MemoryStream ms = new ();
                    filepart.Data.CopyTo(ms);
                    record = new(filepart.Name, filepart.FileName, filepart.ContentType, ms.ToArray());
                    PartContentList.Add(record);
                }

                Success = true;
                ErrorMessage = "";

            }
            catch (Exception e)
            {
                Success = false;
                ErrorMessage = e.Message + " - " + e.StackTrace;
            }
        }
    }
}