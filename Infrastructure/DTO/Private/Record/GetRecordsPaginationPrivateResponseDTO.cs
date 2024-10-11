namespace HowClient.Infrastructure.DTO.Private.Record;

using Models;

public sealed class GetRecordsPaginationPrivateResponseDTO
{
    public int Count { get; set; }
    public List<RecordItemModelDTO> Records { get; set; } = new();
}