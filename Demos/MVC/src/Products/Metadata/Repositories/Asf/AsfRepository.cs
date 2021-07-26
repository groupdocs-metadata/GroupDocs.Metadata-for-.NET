

using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Video;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Asf
{
    public class AsfRepository : EnumMapperRepository
    {
        private static readonly IDictionary<string, Type> EnumMap = new Dictionary<string, Type>
        {
            { "Flags", typeof(AsfFilePropertyFlags) },
        };

        public AsfRepository(MetadataPackage branchPackage) : base(branchPackage, EnumMap)
        {
        }
    }
}