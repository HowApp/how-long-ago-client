namespace HowClient.Infrastructure.DTO.Models;

using Enums;

public class RecordItemModelDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ImageModelDTO> Images { get; set; } = new List<ImageModelDTO>();
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public LikeState OwnLikeState { get; set; }
}