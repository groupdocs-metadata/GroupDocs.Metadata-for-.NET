using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Video;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Asf
{
    public class AsfStreamRepository : EnumMapperRepository
    {
        private static readonly IDictionary<string, Type> EnumMap = new Dictionary<string, Type>
        {
            { "StreamType", typeof(AsfStreamType) },
            { "StreamFlags", typeof(AsfExtendedStreamPropertyFlags) },
        };

        public AsfStreamRepository(MetadataPackage branchPackage) : base(branchPackage, EnumMap)
        {
        }
    }
}