using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Video;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Asf
{
    public class AsfCodecRepository : EnumMapperRepository
    {
        private static readonly IDictionary<string, Type> EnumMap = new Dictionary<string, Type>
        {
            { "CodecEntryType", typeof(AsfCodecType) },
        };

        public AsfCodecRepository(MetadataPackage branchPackage) : base(branchPackage, EnumMap)
        {
        }
    }
}