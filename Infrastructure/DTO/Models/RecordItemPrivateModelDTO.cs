namespace HowClient.Infrastructure.DTO.Models;

using Enums;

public class RecordItemPrivateModelDTO : RecordItemPublicModelDTO
{
    public LikeState OwnLikeState { get; set; }
}