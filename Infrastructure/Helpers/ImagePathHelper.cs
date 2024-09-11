namespace HowClient.Infrastructure.Helpers;

using Configuration;

public class ImagePathHelper
{
    public static string GetPath(string backendUrl, string hash)
    {
        return $"{backendUrl}api/storage/file/{hash}/get-stream";
    }
}