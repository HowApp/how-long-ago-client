namespace HowClient.Infrastructure.Helpers;

using Common.Constants;

public class ImagePathHelper
{
    public static string GetPath(string backendUrl, string hash)
    {
        return string.IsNullOrEmpty(hash) ? ImagePathConstant.NoImage : $"{backendUrl}api/storage/file/{hash}/get-stream";
    }
}