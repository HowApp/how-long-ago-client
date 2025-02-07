namespace HowClient.Infrastructure.Helpers;

using Enums;

public class ApiAccessHelper
{
    public static string GetAccess(ApiRequestAccessFilter filter)
    {
        return filter switch
        {
            ApiRequestAccessFilter.None => "public-active",
            ApiRequestAccessFilter.IncludeCreatedBy => "own",
            ApiRequestAccessFilter.IncludeShared => "shared",
            _ => string.Empty
        };
    }
}