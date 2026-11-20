namespace HowClient.Services.Private.Record;

using Infrastructure.DTO.Private.Record;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Components.Forms;

public interface IRecordPrivateService
{
    Task<GetRecordsPaginationPrivateResponseDTO> GetRecordsPagination(
        int eventId,
        GetRecordsPaginationPrivateRequestDTO request);

    Task<int> CreateRecord(int eventId, string description);
    Task<bool> UpdateRecord(int eventId, int recordId, string description);
    Task<bool> DeleteRecord(int eventId, int recordId);
    Task<LikeState> UpdateRecordLikeState(int eventId, int recordId, LikeState likeState);
    Task<bool> UploadRecordImages(int eventId, int recordId, IReadOnlyList<IBrowserFile> files);
}