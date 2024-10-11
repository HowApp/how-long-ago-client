namespace HowClient.Infrastructure.DTO.Private.Event;

using Common.DTO;
using Enums;

public sealed class GetEventsPaginationPrivateRequestDTO : PaginationDTO
{
    public string Search { get; set; } = string.Empty;
    public EventStatus Status { get; set; }
    public EventAccessType Access { get; set; }
}