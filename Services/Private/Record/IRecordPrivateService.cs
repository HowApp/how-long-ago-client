namespace HowClient.Services.Private.Record;

using Infrastructure.DTO.Private.Record;

public interface IRecordPrivateService
{
    Task<GetRecordsPaginationPrivateResponseDTO> GetRecordsPagination(
        int eventId,
        GetRecordsPaginationPrivateRequestDTO request);
}