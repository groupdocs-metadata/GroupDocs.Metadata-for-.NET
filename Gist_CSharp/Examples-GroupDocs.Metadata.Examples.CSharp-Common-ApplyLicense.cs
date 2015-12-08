/// <summary>
/// Applies product license
/// </summary>
public static void ApplyLicense()
{
    try
    {
        // initialize License
        License lic = new License();

        // apply license
        lic.SetLicense(LicenseFilePath);
    }
    catch (Exception exp)
    {
        Console.WriteLine(exp.Message);
    }
}
