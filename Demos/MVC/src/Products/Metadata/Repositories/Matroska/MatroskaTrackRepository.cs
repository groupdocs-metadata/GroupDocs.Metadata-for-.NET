
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Video;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Matroska
{
    public class MatroskaTrackRepository : EnumMapperRepository
    {
        private static readonly IDictionary<string, Type> EnumMap = new Dictionary<string, Type>
        {
            { "TrackType", typeof(MatroskaTrackType) },
            { "FlagInterlaced", typeof(MatroskaVideoFlagInterlaced) },
            { "FieldOrder", typeof(MatroskaVideoFieldOrder) },
            { "StereoMode", typeof(MatroskaVideoStereoMode) },
            { "DisplayUnit", typeof(MatroskaVideoDisplayUnit) },
        };

        public MatroskaTrackRepository(MetadataPackage branchPackage) : base(branchPackage, EnumMap)
        {
        }
    }
}