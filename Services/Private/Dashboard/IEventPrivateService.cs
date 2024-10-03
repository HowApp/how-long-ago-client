namespace HowClient.Services.Private.Dashboard;

using Infrastructure.DTO.Private.Dashboard.Event;
using Infrastructure.DTO.Public.Event;

public interface IEventPrivateService
{
    Task<GetEventsPaginationPrivateResponseDTO> GetEventsPagination(GetEventsPaginationPrivateRequestDTO request);
    Task<GetEventByIdResponseDTO> GetEventById(int eventId);
    Task UpdateEventAccessState(int eventId, bool setPublic);
    Task UpdateEventActiveState(int eventId, bool setActive);
}