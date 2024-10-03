namespace HowClient.Infrastructure.DTO.Models;

using Enums;
using Internal;

public class EventItemPrivateModelDTO : EventItemPublicModelDTO
{
    
    public EventStatus Status { get; set; }
    public EventAccessType Access { get; set; }
   
}