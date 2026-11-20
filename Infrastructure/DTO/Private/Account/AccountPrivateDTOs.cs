namespace HowClient.Infrastructure.DTO.Private.Account;

using Models;

public class GetUserInfoPrivateResponseDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ImageModelDTO Image { get; set; } = new();
}

public class UpdateUserInfoPrivateRequestDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class UpdateUserImagePrivateResponseDTO
{
    public string MainHash { get; set; } = string.Empty;
    public string ThumbnailHash { get; set; } = string.Empty;
}

public class GetUsersListPrivateResponseDTO
{
    public List<UserInfoModelShortDTO> Users { get; set; } = [];
}

public class CreateSharedUserPrivateRequestDTO
{
    public int UserId { get; set; }
}

public class DeleteSharedUserPrivateRequestDTO
{
    public int SharedUserId { get; set; }
}
