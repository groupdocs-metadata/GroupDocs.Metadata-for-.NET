/// <summary>
/// Maps destination file path
/// </summary>
/// <param name="DestinationFileName">Destination File Name</param>
/// <returns>Returns complete path of destination file</returns>
public static string MapDestinationFilePath(string DestinationFileName)
{
    try
    {
        return DestinationFolderPath + DestinationFileName;
    }
    catch (Exception exp)
    {
        Console.WriteLine(exp.Message);
        return exp.Message;
    }
}
