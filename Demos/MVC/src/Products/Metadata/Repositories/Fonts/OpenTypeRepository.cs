
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Font;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Fonts
{
    public class OpenTypeRepository : EnumMapperRepository
    {
        private const string GlyphBounds = "GlyphBounds";
        private static readonly IDictionary<string, Type> EnumMap = new Dictionary<string, Type>
        {
            { "SfntVersion", typeof(OpenTypeVersion) },
            { "Flags", typeof(OpenTypeFlags) },
            { "MacStyle", typeof(OpenTypeStyles) },
            { "FontDirectionHint", typeof(OpenTypeDirectionHint) },
            { "UsWeightClass", typeof(OpenTypeWeight) },
            { "UsWidthClass", typeof(OpenTypeWidth) },
            { "FsType", typeof(OpenTypeLicensingRights) },
        };

        public OpenTypeRepository(MetadataPackage branchPackage) : base(branchPackage, EnumMap)
        {
        }

        public override IEnumerable<Property> GetProperties()
        {
            foreach (var property in base.GetProperties())
            {
                if (property.Name != GlyphBounds)
                {
                    yield return property;
                }
            }

            var font = (OpenTypeFont)BranchPackage;
            yield return new Property(GlyphBounds, PropertyType.String, $"{font.GlyphBounds.Width}X{font.GlyphBounds.Height}");

            var visited = new Dictionary<OpenTypeName, int>();

            foreach (var name in font.Names)
            {
                if (visited.ContainsKey(name.NameID))
                {
                    visited[name.NameID]++;
                }
                else
                {
                    visited.Add(name.NameID, 1);
                }
                yield return new Property($"z_{name.NameID} {visited[name.NameID]}", PropertyType.String, name.Value);
            }
        }
    }
}