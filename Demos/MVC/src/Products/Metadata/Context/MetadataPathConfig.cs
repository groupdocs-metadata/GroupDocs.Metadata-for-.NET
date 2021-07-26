using System;
using System.Collections.Generic;
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Archive;
using GroupDocs.Metadata.Formats.BusinessCard;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Formats.Font;
using GroupDocs.Metadata.Formats.Peer2Peer;
using GroupDocs.Metadata.Formats.Video;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Context
{
    public class MetadataPathConfig
    {
        private const char PathSeparator = '/';

        private readonly IDictionary<Type, string[]> metadataPaths = new Dictionary<Type, string[]>
        {
            { typeof(NoteInspectionPackage), new[] { "Pages" } },
            { typeof(ZipPackage), new[] { "Files" } },
            { typeof(TorrentPackage), new[] { "files" } },
            { typeof(MovPackage), new[] { "Atoms" } },
            { typeof(MatroskaPackage), new[] { "EbmlHeader", "Segments", "Tracks", "Tags" } },
            { typeof(VCardPackage), new[] { "Cards" } },
            { typeof(AsfPackage), new[] { "StreamProperties", "MetadataDescriptors", "CodecInformation" } },
            { typeof(OpenTypePackage), new[] { "Fonts" } },
        };

        public IEnumerable<NestedPackageInfo> GetRegisteredPackages(MetadataPackage branchPackage)
        {
            yield return new NestedPackageInfo(branchPackage, string.Empty);
            var packageType = branchPackage.GetType();
            if (metadataPaths.ContainsKey(packageType))
            {
                foreach (var packagePath in metadataPaths[packageType])
                {
                    foreach (var nestedPackage in GetPackages(branchPackage, packagePath))
                    {
                        yield return nestedPackage;
                    }
                }
            }
        }

        public MetadataPackage GetPackageByPath(MetadataPackage branchPackage, string path)
        {
            foreach (var packageInfo in GetPackages(branchPackage, path))
            {
                return packageInfo.Package;
            }

            return null;
        }

        public string CombinePath(string part1, string part2)
        {
            part1 = part1.Trim(PathSeparator);
            part2 = part2.Trim(PathSeparator);

            if (part1 == string.Empty)
            {
                return part2;
            }
            if (part2 == string.Empty)
            {
                return part1;
            }
            return string.Concat(part1, PathSeparator, part2);
        }

        private IEnumerable<NestedPackageInfo> GetPackages(MetadataPackage branchPackage, string path)
        {
            var parts = path.Split(PathSeparator);
            var current = branchPackage;

            int i = 0;

            while (i < parts.Length && current != null)
            {
                MetadataPackage next = null;
                if (current.Contains(parts[i]))
                {
                    var property = current[parts[i]];
                    if (property.Value != null)
                    {
                        if (property.Value.Type == MetadataPropertyType.Metadata)
                        {
                            next = property.Value.ToClass<MetadataPackage>();
                        }
                        else if (property.Value.Type == MetadataPropertyType.MetadataArray)
                        {
                            var packages = property.Value.ToArray<MetadataPackage>();
                            i++;
                            if (i < parts.Length)
                            {
                                int index;
                                if (int.TryParse(parts[i], out index))
                                {
                                    next = packages[index];
                                }
                            }
                            else
                            {
                                for (int j = 0; j < packages.Length; j++)
                                {
                                    yield return new NestedPackageInfo(packages[j], CombinePath(path, j.ToString()), j);
                                }
                            }
                        }
                    }
                }
                current = next;
                i++;
            }

            if (current != null)
            {
                yield return new NestedPackageInfo(current, path);
            }
        }
    }
}