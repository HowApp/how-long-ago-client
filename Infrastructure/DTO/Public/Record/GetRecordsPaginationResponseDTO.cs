namespace HowClient.Infrastructure.DTO.Public.Record;

using Models;

public sealed class GetRecordsPaginationResponseDTO
{
    public int Count { get; set; }
    public List<RecordItemModelDTO> Records { get; set; } = new();
}