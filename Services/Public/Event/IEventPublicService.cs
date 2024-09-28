namespace HowClient.Services.Public.Event;

using Infrastructure.DTO.Public.Event;

public interface IEventPublicService
{
    Task<GetEventsPaginationPublicResponseDTO> GetEventsPagination(GetEventsPaginationPublicRequestDTO request);
    Task<GetEventByIdResponseDTO> GetEventById(int eventId);
}