namespace HowClient.Services.Private.Record;

using ClientAPI;
using Infrastructure.DTO.Private.Record;
using Microsoft.AspNetCore.WebUtilities;
using ResultType;

public class RecordPrivateService : IRecordPrivateService
{
    private readonly AuthorizedClientAPI _clientApi;

    public RecordPrivateService(AuthorizedClientAPI clientApi)
    {
        _clientApi = clientApi;
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
            
            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Request failed: {e}");
        }

        return new GetRecordsPaginationPrivateResponseDTO();
    }
}