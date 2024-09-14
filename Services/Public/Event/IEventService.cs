namespace HowClient.Services.Public.Event;

using Infrastructure.DTO.Public.Event;

public interface IEventService
{
    Task<GetEventsPaginationPublicResponseDTO> GetEventsPagination(GetEventsPaginationPublicRequestDTO request);
}