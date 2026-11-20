namespace HowClient.Services.Private.Account;

using System.Net.Http.Headers;
using ClientAPI;
using Infrastructure.DTO.Models;
using Infrastructure.DTO.Private.Account;
using InternalNotification;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class AccountPrivateService : IAccountPrivateService
{
    private readonly AuthorizedClientAPI _clientApi;
    private readonly InternalNotificationService _notificationService;

    public AccountPrivateService(
        AuthorizedClientAPI clientApi,
        InternalNotificationService notificationService)
    {
        _clientApi = clientApi;
        _notificationService = notificationService;
    }

    public async Task<GetUserInfoPrivateResponseDTO> GetCurrentUserInfo()
    {
        try
        {
            var response = await _clientApi.GetAsync<ResultResponse<GetUserInfoPrivateResponseDTO>>("api/account/info/current");
            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return new GetUserInfoPrivateResponseDTO();
            }

            return response.Data ?? new GetUserInfoPrivateResponseDTO();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return new GetUserInfoPrivateResponseDTO();
        }
    }

    public async Task<bool> UpdateUserInfo(string firstName, string lastName)
    {
        try
        {
            var response = await _clientApi.PatchAsync<ResultResponse, UpdateUserInfoPrivateRequestDTO>(
                "api/account/info",
                new UpdateUserInfoPrivateRequestDTO
                {
                    FirstName = firstName,
                    LastName = lastName
                });

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return false;
        }
    }

    public async Task<UpdateUserImagePrivateResponseDTO> UpdateUserImage(IBrowserFile file)
    {
        const long maxFileSize = 10 * 1024 * 1024;
        using var requestContent = new MultipartFormDataContent();

        try
        {
            using var memoryStream = new MemoryStream();
            await file.OpenReadStream(maxFileSize).CopyToAsync(memoryStream);
            var fileContent = new ByteArrayContent(memoryStream.ToArray());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            requestContent.Add(
                content: fileContent,
                name: "\"File\"",
                fileName: file.Name);

            var request = new HttpRequestMessage(HttpMethod.Put, "api/account/image")
            {
                Content = requestContent
            };

            var response = await _clientApi.SendRequest<ResultResponse<UpdateUserImagePrivateResponseDTO>>(request);
            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return null;
            }

            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return null;
        }
    }

    public async Task<List<UserInfoModelShortDTO>> SearchUsersByName(string search)
    {
        try
        {
            var url = QueryHelpers.AddQueryString(
                "api/account/info/by-user-name",
                new Dictionary<string, string> { { "Search", search ?? string.Empty } });

            var response = await _clientApi.GetAsync<ResultResponse<GetUsersListPrivateResponseDTO>>(url);
            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return [];
            }

            return response.Data?.Users ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return [];
        }
    }

    public async Task<List<UserInfoModelShortDTO>> GetSharedUsers()
    {
        try
        {
            var response = await _clientApi.GetAsync<ResultResponse<GetUsersListPrivateResponseDTO>>("api/dashboard/shared-user/get");
            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return [];
            }

            return response.Data?.Users ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return [];
        }
    }

    public async Task<bool> AddSharedUser(int userId)
    {
        try
        {
            var response = await _clientApi.PostAsync<ResultResponse<int>, CreateSharedUserPrivateRequestDTO>(
                "api/dashboard/shared-user/create",
                new CreateSharedUserPrivateRequestDTO { UserId = userId });

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return false;
        }
    }

    public async Task<bool> DeleteSharedUser(int sharedUserId)
    {
        try
        {
            var response = await _clientApi.DeleteAsync<ResultResponse, DeleteSharedUserPrivateRequestDTO>(
                "api/dashboard/shared-user/delete",
                new DeleteSharedUserPrivateRequestDTO { SharedUserId = sharedUserId });

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return false;
        }
    }
}
