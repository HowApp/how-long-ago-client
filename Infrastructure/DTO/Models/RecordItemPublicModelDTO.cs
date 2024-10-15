namespace HowClient.Infrastructure.DTO.Models;

public class RecordItemPublicModelDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ImageModelDTO> Images { get; set; } = new();
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}