namespace HowClient.Services.Public.Event;

using ClientAPI;
using Infrastructure.DTO.Public.Event;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class EventPublicService : IEventPublicService
{
    private readonly AnonymousClientAPI _clientApi;

    public EventPublicService(AnonymousClientAPI clientApi)
    {
        _clientApi = clientApi;
    }

    public async Task<GetEventsPaginationPublicResponseDTO> GetEventsPagination(GetEventsPaginationPublicRequestDTO request)
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
            
            var url = QueryHelpers.AddQueryString("api/public/event/list-pagination", queryParams);
            
            var response = await _clientApi.GetAsync<ResultResponse<GetEventsPaginationPublicResponseDTO>>(url);
            
            if (response.Failed)
            {
                return new GetEventsPaginationPublicResponseDTO();
            }
            
            return response.Data;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request failed: {e}");
        }
        
        return new GetEventsPaginationPublicResponseDTO();
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