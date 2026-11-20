namespace HowClient.Services.Private.Record;

using System.Net.Http.Headers;
using ClientAPI;
using Infrastructure.DTO.Private.Record;
using Infrastructure.Enums;
using InternalNotification;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class RecordPrivateService : IRecordPrivateService
{
    private readonly AuthorizedClientAPI _clientApi;
    private readonly InternalNotificationService _notificationService;

    public RecordPrivateService(
        AuthorizedClientAPI clientApi,
        InternalNotificationService notificationService)
    {
        _clientApi = clientApi;
        _notificationService = notificationService;
    }

    public async Task<GetRecordsPaginationPrivateResponseDTO> GetRecordsPagination(
        int eventId,
        GetRecordsPaginationPrivateRequestDTO request)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "Page", request.Page.ToString() },
                { "Size", request.Size.ToString() }
            };

            var url = QueryHelpers.AddQueryString($"api/dashboard/event/{eventId}/record/list-pagination", queryParams);

            var response = await _clientApi.GetAsync<ResultResponse<GetRecordsPaginationPrivateResponseDTO>>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return new GetRecordsPaginationPrivateResponseDTO();
            }

            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }

        return new GetRecordsPaginationPrivateResponseDTO();
    }

    public async Task<int> CreateRecord(int eventId, string description)
    {
        try
        {
            var response = await _clientApi.PostAsync<ResultResponse<int>, CreateUpdateRecordPrivateRequestDTO>(
                $"api/dashboard/event/{eventId}/record/create",
                new CreateUpdateRecordPrivateRequestDTO { Description = description });

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return -1;
            }

            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return -1;
        }
    }

    public async Task<bool> UpdateRecord(int eventId, int recordId, string description)
    {
        try
        {
            var response = await _clientApi.PatchAsync<ResultResponse, CreateUpdateRecordPrivateRequestDTO>(
                $"api/dashboard/event/{eventId}/record/{recordId}/update",
                new CreateUpdateRecordPrivateRequestDTO { Description = description });

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

    public async Task<bool> DeleteRecord(int eventId, int recordId)
    {
        try
        {
            var response = await _clientApi.DeleteAsync<ResultResponse>(
                $"api/dashboard/event/{eventId}/record/{recordId}/delete");

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

    public async Task<LikeState> UpdateRecordLikeState(int eventId, int recordId, LikeState likeState)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "request", ((int)likeState).ToString() }
            };

            var url = QueryHelpers.AddQueryString(
                $"api/dashboard/event/{eventId}/record/{recordId}/like",
                queryParams);

            var response = await _clientApi.PatchAsync<ResultResponse<LikeState>>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return likeState;
            }

            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return likeState;
        }
    }

    public async Task<bool> UploadRecordImages(int eventId, int recordId, IReadOnlyList<IBrowserFile> files)
    {
        const long maxFileSize = 10 * 1024 * 1024;
        using var requestContent = new MultipartFormDataContent();

        try
        {
            foreach (var file in files.Take(5))
            {
                using var memoryStream = new MemoryStream();
                await file.OpenReadStream(maxFileSize).CopyToAsync(memoryStream);
                var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                requestContent.Add(
                    content: fileContent,
                    name: "\"Files\"",
                    fileName: file.Name);
            }

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"api/dashboard/event/{eventId}/record/{recordId}/image/create")
            {
                Content = requestContent
            };

            var response = await _clientApi.SendRequest<ResultResponse>(request);
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