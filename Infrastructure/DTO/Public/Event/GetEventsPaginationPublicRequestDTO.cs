namespace HowClient.Infrastructure.DTO.Public.Event;

using Common.DTO;

public sealed class GetEventsPaginationPublicRequestDTO : PaginationDTO
{
    public string Search { get; set; } = string.Empty;
}