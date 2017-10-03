using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Metadata.Examples.CSharp.Utilities
{
    //ExStart:DocumentTypeDetector
    public static class DocumentTypeDetector
    {
        /// <summary>
        /// Gets and returns document type in the file
        /// </summary>
        /// <param name="path">File Path</param> 
        public static DocumentType GetDocumentType(string path)
        {
            using (FileFormatChecker fileFormatChecker = new FileFormatChecker(path))
            {
                return fileFormatChecker.GetDocumentType();
            }
        }

        /// <summary>
        /// Gets and returns files of a specific document type
        /// </summary>
        /// <param name="directory">Directory Path</param>
        /// <param name="documentType">Document Type</param>
        /// <returns>String array containing file paths</returns>
        public static string[] GetFiles(string directory, DocumentType documentType)
        {
            // get all files using Directory.GetFiles approach
            string[] files = Directory.GetFiles(directory, "*.*");

            // return empty array if directory is empty
            if (files.Length == 0)
            {
                return new string[0];
            }

            List<string> result = new List<string>();

            foreach (string path in files)
            {
                using (FileFormatChecker fileFormatChecker = new FileFormatChecker(path))
                {
                    if (fileFormatChecker.VerifyFormat(documentType))
                    {
                        result.Add(path);
                    }
                }
            }

            return result.ToArray();
        }

    }
    //ExEnd:DocumentTypeDetector
}
