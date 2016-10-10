using GroupDocs.Metadata;
using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//ExStart:DocumentTypeDetectorDirectoryExtension
namespace System.IO
{
    public static class MyExtension
    {
        /// <summary>
        /// Gets and returns files of a specific document type
        /// </summary>
        /// <param name="directory">Directory Path</param>
        /// <param name="documentType">Document Type</param>
        /// <returns>File info array</returns>
        public static FileInfo[] GetFiles(this DirectoryInfo directoryInfo, DocumentType documentType)
        {
            FileInfo[] files = directoryInfo.GetFiles();

            // return empty array if directory is empty
            if (files.Length == 0)
            {
                return new FileInfo[0];
            }

            List<FileInfo> result = new List<FileInfo>();

            foreach (FileInfo fileInfo in files)
            {
                using (FileFormatChecker fileFormatChecker = new FileFormatChecker(fileInfo.FullName))
                {
                    if (fileFormatChecker.VerifyFormat(documentType))
                    {
                        result.Add(fileInfo);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
//ExEnd:DocumentTypeDetectorDirectoryExtension
