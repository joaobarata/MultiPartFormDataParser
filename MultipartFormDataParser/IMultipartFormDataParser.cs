using MultiPartFormData.Structures;
using OutSystems.ExternalLibraries.SDK;

namespace MultiPartFormData
{
    [OSInterface(Description = "Extension used to parse Multipart/form-data.", IconResourceName = "MultipartFormDataParser.resources.logo.png", Name = "MultipartFormDataParser")]
    public interface IMultipartFormDataParser
    {
        [OSAction(Description = "Action that parses a binary file sent with MultiPart/Form Data.", IconResourceName = "MultipartFormDataParser.resources.logo.png")]
        public void Parse_MultiPartFormData(
            [OSParameter(Description = "Multipart/form-data binary content")]
            byte[] MultipartBinary,
            [OSParameter(Description = "Boundary string used to delimit the different parts. If left blank, the boundary will be auto-detected.\r\n\r\n\r\nNote: Boundary auto-detect expects the boundary to be on the first line of the MultiPartBinary")]
            string Boundary,
            [OSParameter(Description = "List of the parsed Multipart/FormData binary")]
            out List<PartContent> PartContentList,
            [OSParameter(Description = "Returns true if no errors occurred")]
            out bool Success,
            [OSParameter(Description = "Exception message in case of error")]
            out string ErrorMessage,
            [OSParameter(Description = "File encoding, defaults to utf-8. Available encodings: ascii, unicode, utf-8")]
            string FileEncoding = "utf-8");
    }
}
