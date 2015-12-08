/// <summary>
/// Maps source file path
/// </summary>
/// <param name="FileName">Source File Name</param>
/// <returns>Returns complete path of source file</returns>
public static string MapSourceFilePath(string SourceFileName)
{
    try
    {
        return SourceFolderPath + SourceFileName;
    }
    catch (Exception exp)
    {
        Console.WriteLine(exp.Message);
        return exp.Message;
    }
}
