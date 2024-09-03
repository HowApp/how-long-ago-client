namespace HowClient.Infrastructure.DTO.Models;

using Enums;

public class EventItemModelDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EventAccessType Access { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public LikeState OwnLikeState { get; set; }
    public int SavedCount { get; set; }
    public bool IsSavedByUser { get; set; }
}