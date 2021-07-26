﻿using GroupDocs.Metadata.WebForms.Products.Common.Entity.Web;
using System;
using System.IO;

namespace GroupDocs.Metadata.WebForms.Products.Common.Resources
{
    /// <summary>
    /// Resources
    /// </summary>
    public static class Resources
    {
        /// <summary>
        /// Get free file name for uploaded file if such file already exists
        /// </summary>
        /// <param name="directory">Directory where to search files</param>
        /// <param name="fileName">Uploaded file name</param>
        /// <returns></returns>
        public static string GetFreeFileName(string directory, string fileName)
        {
            string resultFileName = "";

            // get all files from the directory
            string[] listOfFiles = Directory.GetFiles(directory);
            for (int i = 0; i < listOfFiles.Length; i++)
            {
                // check if file with current name already exists
                int number = i + 1;
                string newFileName = Path.GetFileNameWithoutExtension(fileName) + "-Copy(" + number + ")." + Path.GetExtension(fileName);
                resultFileName = Path.Combine(directory, newFileName);
                if (!File.Exists(resultFileName))
                {
                    break;
                }
            }

            return resultFileName;
        }

        /// <summary>
        /// Generate exception
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>ExceptionEntity</returns>
        public static ExceptionEntity GenerateException(Exception ex)
        {
            // Initiate Exception entity
            ExceptionEntity exceptionEntity = new ExceptionEntity();
            // set exception data
            exceptionEntity.message = ex.Message;
            exceptionEntity.exception = ex;
            return exceptionEntity;
        }

        /// <summary>
        /// Generate exception for password error
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="password">string</param>
        /// <returns>ExceptionEntity</returns>
        public static ExceptionEntity GenerateException(Exception ex, string password)
        {
            // Initiate exception
            ExceptionEntity exceptionEntity = new ExceptionEntity();
            // Check if exception message contains password and password is empty
            if (ex.Message.Contains("password") && String.IsNullOrEmpty(password))
            {
                exceptionEntity.message = "Password Required";
            }
            // Check if exception contains password and password is set
            else if (ex.Message.Contains("password") && !String.IsNullOrEmpty(password))
            {
                exceptionEntity.message = "Incorrect password";
            }
            else
            {
                exceptionEntity.message = ex.Message;
                exceptionEntity.exception = ex;
            }
            return exceptionEntity;
        }
    }
}