namespace HowClient.Infrastructure.DTO.Models;

using Internal;

public class EventItemPublicModelDTO : EventItemModelInternal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ImageModelDTO Image { get; set; }
    public UserInfoModelShortDTO UserInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public int SavedCount { get; set; }
}