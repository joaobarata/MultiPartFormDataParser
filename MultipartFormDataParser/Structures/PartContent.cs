using OutSystems.ExternalLibraries.SDK;

namespace MultiPartFormData.Structures
{
    /// <summary>
    /// The Iban struct represents an International Bank Account Number (IBAN)
    /// and its components. It's exposed as a structure to your ODC apps and
    /// libraries.
    /// </summary>
    [OSStructure]
    public struct PartContent
    {
        /// <summary>
        /// Header Name.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Name of the part", IsMandatory = true)]
        public string Name;

        /// <summary>
        /// Header Value.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Optional filename, if the part contains file data", IsMandatory = false)]
        public string Filename = "";

        /// <summary>
        /// Header Value.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Optional content type", IsMandatory = false)]
        public string ContentType;
        /// <summary>
        /// Header Value.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Text content. Mandatory if ContentBinary is not supplied. If suoplied, ContentBinary is ignored.", IsMandatory = false)]
        public string Content = "";

        /// <summary>
        /// Header Value.
        /// </summary>
        [OSStructureField(DataType = OSDataType.BinaryData, Description = "Binary content. Mandatory if Content is not supplied.", IsMandatory = false)]
        public byte[]? BinaryContent = null;

        /// <summary>
        /// Constructs an Header object.
        /// </summary>
        public PartContent(string name, string filename, string contentType, string content, byte[]? binaryContent) : this()
        {
            Name = name;
            Filename = filename;
            Content = content;
            ContentType = contentType;
            BinaryContent = binaryContent;
        }

        public PartContent(string name, string filename, string contentType, byte[]? binaryContent) : this()
        {
            Name = name;
            Filename = filename;
            ContentType = contentType;
            BinaryContent = binaryContent;
        }

        public PartContent(string name, string content) : this()
        {
            Name = name;
            Filename = "";
            ContentType = "";
            Content = content;
            BinaryContent = null;
        }
    }

}