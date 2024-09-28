namespace HowClient.Services.Private.Dashboard;

using ClientAPI;
using Infrastructure.DTO.Private.Dashboard.Event;
using Infrastructure.DTO.Public.Event;
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

    public async Task<GetEventsPaginationPrivateResponseDTO> GetEventsPagination(GetEventsPaginationPrivateRequestDTO request)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "Page", request.Page.ToString() },
                { "Size", request.Size.ToString() }
            };
            if (!string.IsNullOrEmpty(request.Search))
            {
                queryParams.Add("search", request.Search);
            }
            
            var url = QueryHelpers.AddQueryString("api/dashboard/event/list-pagination/own", queryParams);
            
            var response = await _clientApi.GetAsync<ResultResponse<GetEventsPaginationPrivateResponseDTO>>(url);

            if (response.Failed)
            {
                _notificationService.NotifyError(response.ToString());
            }
            
            return response.Data;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request failed: {e}");
        }
        
        return new GetEventsPaginationPrivateResponseDTO();
    }

    public async Task<GetEventByIdResponseDTO> GetEventById(int eventId)
    {
        try
        {
            var url = $"api/public/event/{eventId}/details";
            
            var response = await _clientApi.GetAsync<ResultResponse<GetEventByIdResponseDTO>>(url);
            
            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }

        return new GetEventByIdResponseDTO();
    }
}