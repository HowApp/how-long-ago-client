namespace HowClient.Infrastructure.DTO.Private.Event;

using Models;

public sealed class GetEventsPaginationPrivateResponseDTO
{
    public int Count { get; set; }
    public List<EventItemPrivateModelDTO> Events { get; set; } = new();
}