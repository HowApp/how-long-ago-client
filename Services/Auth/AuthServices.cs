namespace HowClient.Services.Auth;

using Infrastructure.DTO.Auth;
using Infrastructure.Models.Services.Auth;

public class AuthServices : IAuthServices
{
    public Task Login(LoginRequestDTO request)
    {
        throw new NotImplementedException();
    }

    public Task Register(RegisterRequestDTO request)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public Task<CurrentUser> CurrentUserInfo()
    {
        throw new NotImplementedException();
    }
}