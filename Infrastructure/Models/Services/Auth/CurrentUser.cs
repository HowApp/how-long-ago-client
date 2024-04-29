namespace HowClient.Infrastructure.Models.Services.Auth;

public class CurrentUser
{
    public bool IsAuthenticate { get; set; }
    public string UserName { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}