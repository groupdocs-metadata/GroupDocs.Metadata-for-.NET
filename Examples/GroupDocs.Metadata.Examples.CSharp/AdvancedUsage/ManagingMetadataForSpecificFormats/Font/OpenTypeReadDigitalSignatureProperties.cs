// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Font
{
    using System;
    using Formats.Font;
    using Standards.Pkcs;

    /// <summary>
    /// This code snippet demonstrates how to extract digital signatures associated with an OpenType font.
    /// </summary>
    public static class OpenTypeReadDigitalSignatureProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputTtf))
            {
                var root = metadata.GetRootPackage<OpenTypeRootPackage>();

                if (root.DigitalSignaturePackage != null)
                {
                    Console.WriteLine(root.DigitalSignaturePackage.Flags);
                    foreach (var signature in root.DigitalSignaturePackage.Signatures)
                    {
                        Console.WriteLine(signature.SignTime);
                        if (signature.DigestAlgorithms != null)
                        {
                            foreach (var signatureDigestAlgorithm in signature.DigestAlgorithms)
                            {
                                PrintOid(signatureDigestAlgorithm);
                            }
                        }
                        if (signature.EncapsulatedContent != null)
                        {
                            PrintOid(signature.EncapsulatedContent.ContentType);
                            Console.WriteLine(signature.EncapsulatedContent.ContentRawData.Length);
                        }
                        if (signature.Certificates != null)
                        {
                            foreach (var certificate in signature.Certificates)
                            {
                                Console.WriteLine(certificate.NotAfter);
                                Console.WriteLine(certificate.NotBefore);
                                Console.WriteLine(certificate.RawData.Length);
                            }
                        }
                        if (signature.Signers != null)
                        {
                            foreach (var signerInfoEntry in signature.Signers)
                            {
                                Console.WriteLine(signerInfoEntry.SignatureValue);
                                PrintOid(signerInfoEntry.DigestAlgorithm);
                                PrintOid(signerInfoEntry.SignatureAlgorithm);
                                Console.WriteLine(signerInfoEntry.SigningTime);
                                PrintAttributes(signerInfoEntry.SignedAttributes);
                                PrintAttributes(signerInfoEntry.UnsignedAttributes);
                            }
                        }
                    }
                }
            }
        }

        private static void PrintOid(Oid oid)
        {
            // Display the property name and value of OID
            if (oid != null)
            {
                Console.WriteLine(oid.FriendlyName);
                Console.WriteLine(oid.Value);
            }
        }

        private static void PrintAttributes(CmsAttribute[] attributes)
        {
            //Display the CmsAttributes of an OID
            if (attributes != null)
            {
                foreach (CmsAttribute attribute in attributes)
                {
                    PrintOid(attribute.Oid);
                    Console.WriteLine(attribute.Value);
                }
            }
        }
    }
}
