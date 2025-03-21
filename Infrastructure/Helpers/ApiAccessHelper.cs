namespace HowClient.Infrastructure.Helpers;

using Enums;

public class ApiAccessHelper
{
    public static string GetAccess(ApiRequestAccessFilter filter)
    {
        return filter switch
        {
            ApiRequestAccessFilter.None => "public-active",
            ApiRequestAccessFilter.Own => "own",
            ApiRequestAccessFilter.Shared => "shared",
            _ => string.Empty
        };
    }
}