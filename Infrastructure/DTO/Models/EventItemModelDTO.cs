namespace HowClient.Infrastructure.DTO.Models;

using Enums;
using Internal;

public class EventItemModelDTO : EventItemModelInternal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EventAccessType Access { get; set; }
    public ImageModelDTO Image { get; set; }
    public UserInfoModelShortDTO UserInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public LikeState OwnLikeState { get; set; }
    public int SavedCount { get; set; }
    public bool IsSavedByUser { get; set; }
}