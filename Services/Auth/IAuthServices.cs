namespace HowClient.Services.Auth;

using Infrastructure.DTO.Auth;
using Infrastructure.Models.Services.Auth;

public interface IAuthServices
{
    Task Login(LoginRequestDTO request);
    Task Register(RegisterRequestDTO request);
    Task Logout();
    Task<CurrentUser> CurrentUserInfo();
}