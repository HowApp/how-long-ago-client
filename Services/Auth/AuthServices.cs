namespace HowClient.Services.Auth;

using ClientAPI;
using Infrastructure.DTO.Auth;
using Infrastructure.Models.Services.Auth;
using ResultType;

public class AuthServices : IAuthServices
{
    private readonly AuthorizedClientAPI _authorizedClientApi;

    public AuthServices(AuthorizedClientAPI authorizedClientApi)
    {
        _authorizedClientApi = authorizedClientApi;
    }

    public async Task Login(LoginRequestDTO request)
    {
        await _authorizedClientApi.PostAsync<ResultResponse, LoginRequestDTO>("api/identity/login", request);
    }

    public async Task Register(RegisterRequestDTO request)
    {
        await _authorizedClientApi.PostAsync<ResultResponse, RegisterRequestDTO>("api/identity/register", request);
    }

    public async Task Logout()
    {
        await _authorizedClientApi.PostAsync<ResultResponse>("api/identity/logout");
    }

    public async Task<CurrentUser> CurrentUserInfo()
    {
        var response = await _authorizedClientApi.GetAsync<ResultResponse<CurrentUserResponseDTO>>("api/identity/current-user-info");

        if (response.Data is null)
        {
            return new CurrentUser();
        }

        var result = new CurrentUser
        {
            IsAuthenticate = response.Data.IsAuthenticate,
            UserName = response.Data.UserName,
            Claims = response.Data.Claims
        };

        return result;
    }
}