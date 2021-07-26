

using GroupDocs.Metadata.Common;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Context
{
    public class NestedPackageInfo
    {
        public NestedPackageInfo(MetadataPackage package, string path, int index)
        {
            Package = package;
            Path = path;
            Index = index;
        }

        public NestedPackageInfo(MetadataPackage package, string path) : this(package, path, -1)
        {
        }

        public MetadataPackage Package { get; private set; }

        public string Path { get; private set; }

        public int Index { get; private set; }
    }
}