
using System;
using System.Globalization;
using System.Text;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Util
{
    public static class ArrayUtil
    {
        private const int ArrayMaxLength = 10;
        private const string ArrayStartCharacter = "[";
        private const string ArrayEndCharacter = "]";

        public static string AsString(Array array)
        {
            StringBuilder builder = new StringBuilder();
            if (array != null)
            {
                if (array.Length > 0)
                {
                    builder.Append(ArrayStartCharacter);
                    for (int index = 0; index < array.Length; index++)
                    {
                        object item = array.GetValue(index);
                        builder.AppendFormat(CultureInfo.InvariantCulture, "{0},", item);
                        if (index > ArrayMaxLength)
                        {
                            builder.Append("...");
                            break;
                        }
                    }

                    // remove the last comma character
                    builder.Length--;
                    builder.Append(ArrayEndCharacter);
                }
            }

            return builder.ToString();
        }
    }
}