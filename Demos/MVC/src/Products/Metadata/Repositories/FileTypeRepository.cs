
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Document;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public class FileTypeRepository : EnumMapperRepository
    {
        private static readonly IDictionary<string, Type> EnumMap = new Dictionary<string, Type>
        {
            { "FileFormat", typeof(FileFormat) },
            { "DiagramFileFormat", typeof(DiagramFormat) },
            { "PresentationFileFormat", typeof(PresentationFormat) },
            { "SpreadsheetFileFormat", typeof(SpreadsheetFormat) },
            { "WordProcessingFileFormat", typeof(WordProcessingFormat) },
            { "ByteOrder", typeof(ByteOrder) },
        };

        public FileTypeRepository(MetadataPackage branchPackage) : base(branchPackage, EnumMap)
        {
        }
    }
}