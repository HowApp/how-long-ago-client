namespace HowClient.Infrastructure.DTO.Public.Event;

using Models;

public sealed class GetEventsPaginationPublicResponseDTO
{
    public int Count { get; set; }
    public List<EventItemModelDTO> Events { get; set; } = new List<EventItemModelDTO>();
}