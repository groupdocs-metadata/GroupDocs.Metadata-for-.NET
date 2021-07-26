
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Audio;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public class ID3V2TagRepository : MetadataPackageRepository
    {
        private const string WxxxFrameName = "WXXX";
        private const string TxxxFrameName = "TXXX";
        private const int FrameNameLength = 4;
        private const char FrameNumberSeparator = '-';
        private const string TextFrameStart = "T";
        private const string UrlLinkFrameStart = "W";

        public ID3V2TagRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        public override IEnumerable<Property> GetProperties()
        {
            foreach (var property in BranchPackage)
            {
                if (property.Value.Type == MetadataPropertyType.Metadata)
                {
                    var frame = property.Value.ToClass<ID3V2TagFrame>();
                    if (frame != null)
                    {
                        yield return CreateProperty(frame);
                    }
                }
                else if (property.Value.Type == MetadataPropertyType.MetadataArray)
                {
                    var frames = property.Value.ToArray<ID3V2TagFrame>();
                    if (frames != null)
                    {
                        for (int i = 0; i < frames.Length; i++)
                        {
                            yield return CreateProperty(frames[i], i + 1);
                        }
                    }
                }
            }
        }

        public override void RemoveProperty(string name)
        {
            if (name != null)
            {
                if (name.Length == FrameNameLength)
                {
                    base.RemoveProperty(name);
                }
                else
                {
                    string frameId;
                    int frameNumber;
                    if (TryParseFrameName(name, out frameId, out frameNumber))
                    {
                        var tag = (ID3V2Tag)BranchPackage;
                        var frames = tag.Get(frameId);
                        if (frames != null && frameNumber <= frames.Length)
                        {
                            tag.Remove(frames[frameNumber - 1]);
                        }
                    }
                }
            }
        }

        public override void SaveProperty(string name, PropertyType type, dynamic value)
        {
            if (name != null && name.Length == FrameNameLength)
            {
                var tag = (ID3V2Tag)BranchPackage;
                var frame = CreateFrame(name, value);
                if (frame != null)
                {
                    tag.Set(frame);
                }
            }
        }

        public override IEnumerable<Model.PropertyDescriptor> GetDescriptors()
        {
            foreach (var descriptor in BranchPackage.KnowPropertyDescriptors)
            {
                if (descriptor.Type == MetadataPropertyType.Metadata)
                {
                    if (descriptor.Name != null && descriptor.Name.Length == FrameNameLength &&
                        (descriptor.Name.StartsWith(TextFrameStart) || descriptor.Name.StartsWith(UrlLinkFrameStart)) &&
                        descriptor.Name != TxxxFrameName && descriptor.Name != WxxxFrameName)
                    {
                        yield return new Model.PropertyDescriptor(descriptor.Name, PropertyType.String, AccessLevels.Full);
                    }
                    else
                    {
                        yield return new Model.PropertyDescriptor(descriptor.Name, PropertyType.ByteArray, AccessLevels.Remove);
                    }
                }
                else if (descriptor.Type == MetadataPropertyType.MetadataArray)
                {
                    if (BranchPackage.Contains(descriptor.Name))
                    {
                        var property = BranchPackage[descriptor.Name];
                        var frames = property.Value.ToArray<ID3V2TagFrame>();
                        if (frames != null)
                        {
                            for (int i = 0; i < frames.Length; i++)
                            {
                                yield return new Model.PropertyDescriptor(GetPropertyName(frames[i].Id, i + 1), PropertyType.ByteArray, AccessLevels.Remove);
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

        private Property CreateProperty(ID3V2TagFrame frame, int number = 0)
        {
            var name = GetPropertyName(frame.Id, number);
            if (frame is ID3V2TextFrame)
            {
                return new Property(name, PropertyType.String, ((ID3V2TextFrame)frame).Text);
            }

            if (frame is ID3V2UrlLinkFrame)
            {
                return new Property(name, PropertyType.String, ((ID3V2UrlLinkFrame)frame).Url);
            }

            if (frame is ID3V2CommentFrame)
            {
                return new Property(name, PropertyType.String, ((ID3V2CommentFrame)frame).Text);
            }

            return new Property(name, PropertyType.ByteArray, frame.Data);
        }

        private ID3V2TagFrame CreateFrame(string id, object value)
        {
            var stringValue = value as string;

            if (!string.IsNullOrEmpty(stringValue))
            {
                if (id.StartsWith(TextFrameStart))
                {
                    return new ID3V2TextFrame(id, ID3V2EncodingType.Iso88591, stringValue);
                }

                if (id.StartsWith(UrlLinkFrameStart))
                {
                    return new ID3V2UrlLinkFrame(id, stringValue);
                }
            }

            return null;
        }

        private string GetPropertyName(string frameId, int number = 0)
        {
            return number <= 0 ? frameId : $"{frameId}{FrameNumberSeparator}{number}";
        }

        private bool TryParseFrameName(string propertyName, out string frameId, out int frameNumber)
        {
            frameId = null;
            frameNumber = 0;
            var parts = propertyName.Split(FrameNumberSeparator);
            if (parts.Length == 2)
            {
                if (int.TryParse(parts[1], out frameNumber))
                {
                    frameId = parts[0];
                    return true;
                }
            }

            return false;
        }
    }
}