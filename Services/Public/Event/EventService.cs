namespace HowClient.Services.Public.Event;

using ClientAPI;
using Infrastructure.DTO.Public.Event;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class EventService : IEventService
{
    private readonly AnonymousClientAPI _anonymousClientApi; // TODO check for authorized client

    public EventService(AnonymousClientAPI anonymousClientApi)
    {
        _anonymousClientApi = anonymousClientApi;
    }

    public async Task<GetEventsPaginationPublicResponseDTO> GetEventsPagination()
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "page", "1" },
                { "pageSize", "10" },
                { "search", "s" }
            };
            var url = QueryHelpers.AddQueryString("api/public/event/list-pagination", queryParams);
            
            var response = await _anonymousClientApi.GetAsync<ResultResponse<GetEventsPaginationPublicResponseDTO>>(url);
            
            return response.Data;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request failed: {e}");
        }
        
        return new GetEventsPaginationPublicResponseDTO();
    }
}