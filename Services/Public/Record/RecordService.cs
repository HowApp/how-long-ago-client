namespace HowClient.Services.Public.Record;

using ClientAPI;
using Infrastructure.DTO.Public.Record;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class RecordService : IRecordService
{
    private readonly AnonymousClientAPI _anonymousClientApi;

    public RecordService(AnonymousClientAPI anonymousClientApi)
    {
        _anonymousClientApi = anonymousClientApi;
    }

    public async Task<GetRecordsPaginationResponseDTO> GetRecordsPagination(int eventId, GetRecordsPaginationRequestDTO request)
    {
        try
        {
            var queryParams = new Dictionary<string, string>
            {
                { "Page", request.Page.ToString() },
                { "Size", request.Size.ToString() }
            };

            var url = QueryHelpers.AddQueryString($"api/public/event/{eventId}/recordlist-pagination", queryParams);
            
            var response = await _anonymousClientApi.GetAsync<ResultResponse<GetRecordsPaginationResponseDTO>>(url);
            
            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }

        return new GetRecordsPaginationResponseDTO();
    }
}