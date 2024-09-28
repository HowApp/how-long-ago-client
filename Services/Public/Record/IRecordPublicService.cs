namespace HowClient.Services.Public.Record;

using Infrastructure.DTO.Public.Record;

public interface IRecordPublicService
{
    Task<GetRecordsPaginationResponseDTO> GetRecordsPagination(int eventId, GetRecordsPaginationRequestDTO request);
}