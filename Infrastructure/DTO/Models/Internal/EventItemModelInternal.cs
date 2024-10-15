namespace HowClient.Infrastructure.DTO.Models.Internal;

public class EventItemModelInternal
{
    public TimeSpan Duration { get; set; }
    public bool ButtonLikeDisable { get; set; }
    public bool ButtonDislikeDisable { get; set; }
    public bool ButtonSavedDisable { get; set; }
    public bool AccessToggle { get; set; }
    public bool StatusToggle { get; set; }
}