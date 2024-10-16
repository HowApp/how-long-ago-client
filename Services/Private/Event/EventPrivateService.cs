namespace HowClient.Services.Private.Event;

using ClientAPI;
using Infrastructure.DTO.Private.Event;
using Infrastructure.Enums;
using Infrastructure.Helpers;
using InternalNotification;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class EventPrivateService : IEventPrivateService
{
    private readonly AuthorizedClientAPI _clientApi;
    private readonly InternalNotificationService _notificationService;

    public EventPrivateService(
        AuthorizedClientAPI clientApi,
        InternalNotificationService notificationService)
    {
        _clientApi = clientApi;
        _notificationService = notificationService;
    }

    public async Task<GetEventsPaginationPrivateResponseDTO> GetEventsPagination(
        GetEventsPaginationPrivateRequestDTO request,
        ApiRequestAccessFilter accessFilter = ApiRequestAccessFilter.None)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "Page", request.Page.ToString() },
                { "Size", request.Size.ToString() },
                { "Status", request.Status.ToString() },
                { "Access", request.Access.ToString() },
            };
            if (!string.IsNullOrEmpty(request.Search))
            {
                queryParams.Add("search", request.Search);
            }

            var url = QueryHelpers.AddQueryString(
                $"api/dashboard/event/list-pagination/{ApiAccessHelper.GetAccess(accessFilter)}", 
                queryParams);
            
            var response = await _clientApi.GetAsync<ResultResponse<GetEventsPaginationPrivateResponseDTO>>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return new GetEventsPaginationPrivateResponseDTO();
            }
            
            return response.Data;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request failed: {e}");
        }
        
        return new GetEventsPaginationPrivateResponseDTO();
    }

    public async Task<GetEventByIdPrivateResponseDTO> GetEventById(int eventId)
    {
        try
        {
            var url = $"api/dashboard/event/{eventId}/public-active";
            
            var response = await _clientApi.GetAsync<ResultResponse<GetEventByIdPrivateResponseDTO>>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
                return new GetEventByIdPrivateResponseDTO();
            }
            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }

        return new GetEventByIdPrivateResponseDTO();
    }

    public async Task UpdateEventAccessState(int eventId, bool setPublic)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "setPublic", setPublic.ToString() }
            };

            var url = QueryHelpers.AddQueryString($"api/dashboard/event/{eventId}/access-status", queryParams);

            var response = await _clientApi.PatchAsync<ResultResponse>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }
    }

    public async Task UpdateEventActiveState(int eventId, bool setActive)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "setActive", setActive.ToString() }
            };

            var url = QueryHelpers.AddQueryString($"api/dashboard/event/{eventId}/activate-status", queryParams);

            var response = await _clientApi.PatchAsync<ResultResponse>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }
    }

    public async Task<LikeState> UpdateEventLikeState(int eventId, LikeState likeState)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "request", ((int)likeState).ToString() }
            };

            var url = QueryHelpers.AddQueryString($"api/dashboard/event/{eventId}/like", queryParams);

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

    public async Task<bool> AddEventToSaved(int eventId)
    {
        try
        {
            var response = await _clientApi.PostAsync<ResultResponse>($"api/dashboard/event/{eventId}/saved/add");
            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
            }
            
            return response.Succeeded;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return false;
        }
    }

    public async Task<bool> DeleteEventFromSaved(int eventId)
    {
        try
        {
            var response = await _clientApi.DeleteAsync<ResultResponse>($"api/dashboard/event/{eventId}/saved/delete");
            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
            }

            return response.Succeeded;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
            return false;
        }
    }
}