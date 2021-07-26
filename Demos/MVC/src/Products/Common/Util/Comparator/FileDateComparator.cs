using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GroupDocs.Metadata.MVC.Products.Common.Util.Comparator
{
    /// <summary>
    /// FileDateComparator
    /// </summary>
    public class FileDateComparator : IComparer<string>
    {
        /// <summary>
        /// Compare file creation dates
        /// </summary>
        /// <param name="x">string</param>
        /// <param name="y">string</param>
        /// <returns></returns>
        public int Compare(string x, string y)
        {
            var date1 = File.GetCreationTime(x);
            var date2 = File.GetCreationTime(y);

            if (DateTime.Equals(date1, date2))
            {
                return string.Compare(y, x, false, CultureInfo.InvariantCulture);
            }
            else
            {
                return DateTime.Compare(date2, date1);
            }
        }
    }
}