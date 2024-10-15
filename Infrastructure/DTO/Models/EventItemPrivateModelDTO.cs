namespace HowClient.Infrastructure.DTO.Models;

using Enums;

public class EventItemPrivateModelDTO : EventItemPublicModelDTO
{
    
    public EventStatus Status { get; set; }
    public EventAccessType Access { get; set; }
    public LikeState OwnLikeState { get; set; }
    public bool IsSavedByUser { get; set; }
   
}