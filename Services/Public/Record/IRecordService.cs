namespace HowClient.Services.Public.Record;

using Infrastructure.DTO.Public.Record;

public interface IRecordService
{
    Task<GetRecordsPaginationResponseDTO> GetRecordsPagination(int eventId, GetRecordsPaginationRequestDTO request);
}