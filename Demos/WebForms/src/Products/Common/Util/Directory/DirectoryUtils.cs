using System;
using System.Linq;
using System.IO;

namespace GroupDocs.Metadata.WebForms.Products.Common.Util.Directory
{
    public static class DirectoryUtils
    {
        internal static bool IsFullPath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }
    }
}