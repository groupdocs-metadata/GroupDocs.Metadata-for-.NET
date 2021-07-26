using GroupDocs.Metadata.Standards.Iptc;
using System;
using System.Globalization;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Model.IPTC
{
    public class IptcProperty : Property
    {
        private const char NameSeparator = ':';

        public IptcProperty(byte recordNumber, byte dataSetNumber, PropertyType type, object value)
            : base(GetUserFriendlyName(recordNumber, dataSetNumber), type, value)
        {
            RecordNumber = recordNumber;
            DataSetNumber = dataSetNumber;
        }

        public byte RecordNumber { get; private set; }
        public byte DataSetNumber { get; private set; }

        public static string NameToUserFriendlyName(string name)
        {
            byte recordNumber;
            byte dataSetNumber;
            if (TryParseName(name, out recordNumber, out dataSetNumber))
            {
                return GetUserFriendlyName(recordNumber, dataSetNumber);
            }
            return name;
        }

        public static string UserFriendlyNameToName(string userFreindlyName)
        {
            byte recordNumber;
            byte dataSetNumber;
            if (TryParseName(userFreindlyName, out recordNumber, out dataSetNumber))
            {
                return GetName(recordNumber, dataSetNumber);
            }
            return userFreindlyName;
        }

        private static bool TryParseName(string name, out byte recordNumber, out byte dataSetNumber)
        {
            recordNumber = 0;
            dataSetNumber = 0;
            if (name != null)
            {
                var parts = name.Split(NameSeparator);
                if (parts.Length == 2)
                {
                    recordNumber = byte.Parse(parts[0]);
                    dataSetNumber = byte.Parse(parts[1]);
                    return true;
                }
                else
                {
                    IptcEnvelopeRecordDataSet envelopDataSetNumber;
                    if (Enum.TryParse(name, out envelopDataSetNumber))
                    {
                        recordNumber = (byte)IptcRecordType.EnvelopeRecord;
                        dataSetNumber = (byte)envelopDataSetNumber;
                        return true;
                    }
                    else
                    {
                        IptcApplicationRecordDataSet applicationDataSetNumber;
                        if (Enum.TryParse(name, out applicationDataSetNumber))
                        {
                            recordNumber = (byte)IptcRecordType.ApplicationRecord;
                            dataSetNumber = (byte)applicationDataSetNumber;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static string GetUserFriendlyName(int recordNumber, int dataSetNumber)
        {
            if ((IptcRecordType)recordNumber == IptcRecordType.EnvelopeRecord && Enum.IsDefined(typeof(IptcEnvelopeRecordDataSet), dataSetNumber))
            {
                return ((IptcEnvelopeRecordDataSet)dataSetNumber).ToString();
            }

            if ((IptcRecordType)recordNumber == IptcRecordType.ApplicationRecord && Enum.IsDefined(typeof(IptcApplicationRecordDataSet), dataSetNumber))
            {
                return ((IptcApplicationRecordDataSet)dataSetNumber).ToString();
            }

            return GetName(recordNumber, dataSetNumber);
        }

        private static string GetName(int recordNumber, int dataSetNumber)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", recordNumber, NameSeparator, dataSetNumber);
        }
    }
}