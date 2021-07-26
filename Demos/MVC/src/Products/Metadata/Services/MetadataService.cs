using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GroupDocs.Metadata.MVC.Products.Metadata.Config;
using GroupDocs.Metadata.MVC.Products.Metadata.Context;
using GroupDocs.Metadata.MVC.Products.Metadata.DTO;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using GroupDocs.Metadata.MVC.Products.Metadata.Util;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Services
{
    public class MetadataService
    {
        private readonly MetadataConfiguration metadataConfiguration;

        private readonly HashSet<PropertyType> arrayTypes = new HashSet<PropertyType>
        {
            PropertyType.PropertyValueArray,
            PropertyType.StringArray,
            PropertyType.ByteArray,
            PropertyType.DoubleArray,
            PropertyType.IntegerArray,
            PropertyType.LongArray,
        };

        public MetadataService(MetadataConfiguration metadataConfiguration)
        {
            this.metadataConfiguration = metadataConfiguration;
        }

        public IEnumerable<ExtractedPackageDto> GetPackages(PostedDataDto postedData)
        {
            using (MetadataContext context = new MetadataContext(metadataConfiguration.GetAbsolutePath(postedData.guid), postedData.password))
            {
                var packages = new List<ExtractedPackageDto>();
                foreach (var package in context.GetPackages())
                {
                    List<PropertyDto> properties = new List<PropertyDto>();
                    List<KnownPropertyDto> descriptors = new List<KnownPropertyDto>();

                    foreach (var property in package.Properties)
                    {
                        properties.Add(new PropertyDto
                        {
                            name = property.Name,
                            value = property.Value is Array ? ArrayUtil.AsString((Array)property.Value) : property.Value,
                            type = (int)property.Type,
                        });
                    }

                    foreach (var descriptor in package.Descriptors)
                    {
                        var accessLevel = descriptor.AccessLevel;
                        if (arrayTypes.Contains(descriptor.Type))
                        {
                            accessLevel &= AccessLevels.Remove;
                        }

                        descriptors.Add(new KnownPropertyDto
                        {
                            name = descriptor.Name,
                            type = (int)descriptor.Type,
                            accessLevel = (int)accessLevel
                        });
                    }

                    packages.Add(new ExtractedPackageDto
                    {
                        id = package.Id,
                        name = package.Name,
                        index = package.Index,
                        type = (int)package.Type,
                        properties = properties,
                        knownProperties = descriptors,
                    });

                }
                return packages;
            }
        }

        public void SaveProperties(PostedDataDto postedData)
        {
            string filePath = metadataConfiguration.GetAbsolutePath(postedData.guid);
            var tempFilePath = GetTempPath(filePath);
            using (MetadataContext context = new MetadataContext(filePath, postedData.password))
            {
                foreach (var packageInfo in postedData.packages)
                {
                    context.UpdateProperties(packageInfo.id, packageInfo.properties.Select(p => new Property(p.name, (PropertyType)p.type, p.value)));
                }
                context.Save(tempFilePath);
            }

            DirectoryUtils.MoveFile(tempFilePath, filePath);
        }

        public void RemoveProperties(PostedDataDto postedData)
        {
            string filePath = metadataConfiguration.GetAbsolutePath(postedData.guid);
            var tempFilePath = GetTempPath(filePath);
            using (MetadataContext context = new MetadataContext(filePath, postedData.password))
            {
                foreach (var packageInfo in postedData.packages)
                {
                    context.RemoveProperties(packageInfo.id, packageInfo.properties.Select(p => p.name));
                }
                context.Save(tempFilePath);
            }
            DirectoryUtils.MoveFile(tempFilePath, filePath);
        }

        public void CleanMetadata(PostedDataDto postedData)
        {
            string filePath = metadataConfiguration.GetAbsolutePath(postedData.guid);
            var tempFilePath = GetTempPath(filePath);
            using (MetadataContext context = new MetadataContext(filePath, postedData.password))
            {
                context.Sanitize();
                context.Save(tempFilePath);
            }
            DirectoryUtils.MoveFile(tempFilePath, filePath);
        }

        public byte[] ExportMetadata(PostedDataDto postedData)
        {
            using (MetadataContext context = new MetadataContext(metadataConfiguration.GetAbsolutePath(postedData.guid), postedData.password))
            {
                return context.ExportProperties();
            }
        }

        private static string GetTempPath(string filePath)
        {
            string tempFilename = Path.GetFileNameWithoutExtension(filePath) + "_tmp";
            return Path.Combine(Path.GetDirectoryName(filePath), tempFilename + Path.GetExtension(filePath));
        }
    }
}