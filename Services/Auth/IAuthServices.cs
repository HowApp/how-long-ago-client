namespace HowClient.Services.Auth;

using Infrastructure.Models.Services.Auth;

public interface IAuthServices
{
    Task<CurrentUser> CurrentUserInfo();
}