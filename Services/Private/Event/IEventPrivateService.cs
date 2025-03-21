namespace HowClient.Services.Private.Event;

using Infrastructure.DTO.Private.Event;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Components.Forms;

public interface IEventPrivateService
{
    Task<int> CreateEvent(string name);
    Task<GetEventsPaginationPrivateResponseDTO> GetEventsPagination(
        GetEventsPaginationPrivateRequestDTO request,
        ApiRequestAccessFilter accessFilter = ApiRequestAccessFilter.None);
    Task<GetEventByIdPrivateResponseDTO> GetEventById(int eventId);
    Task<bool> UploadImage(int eventId, IBrowserFile file);
    Task<bool> UpdateEvent(int eventId, string name);
    Task UpdateEventAccessState(int eventId, bool setPublic);
    Task UpdateEventActiveState(int eventId, bool setActive);
    Task<LikeState> UpdateEventLikeState(int eventId, LikeState likeState);
    Task<bool> AddEventToSaved(int eventId);
    Task<bool> DeleteEventFromSaved(int eventId);
}