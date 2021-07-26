
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.BusinessCard;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public class VCardRepository : MetadataPackageRepository
    {
        public VCardRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        public override IEnumerable<Property> GetProperties()
        {
            var card = (VCardCard)BranchPackage;
            foreach (var recordsetProperty in card)
            {
                if (recordsetProperty.Value.RawValue is VCardRecordset)
                {
                    foreach (var recordProperty in recordsetProperty.Value.ToClass<VCardRecordset>())
                    {
                        var records = recordProperty.Value.ToArray<VCardRecord>();
                        if (records != null)
                        {
                            for (int i = 0; i < records.Length; i++)
                            {
                                var name = recordProperty.Name.Substring(0, recordProperty.Name.Length - 7);
                                if (records.Length > 1)
                                {
                                    name = $"{name} {i + 1}";
                                }
                                VCardRecord record = records[i];
                                if (record.ContentType == VCardContentType.Text)
                                {
                                    yield return new Property(name, PropertyType.String, ((VCardTextRecord)record).Value);
                                }
                                else if (record.ContentType == VCardContentType.DateTime)
                                {
                                    yield return new Property(name, PropertyType.DateTime, ((VCardDateTimeRecord)record).Value);
                                }
                                else if (record.ContentType == VCardContentType.Custom)
                                {
                                    yield return new Property(name, PropertyType.String, ((VCardCustomRecord)record).Value);
                                }
                                else if (record.ContentType == VCardContentType.Binary)
                                {
                                    yield return new Property(name, PropertyType.ByteArray, ((VCardBinaryRecord)record).Value);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            yield return BranchPackage;
        }
    }
}