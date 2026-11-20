namespace HowClient.Services.Private.Account;

using Infrastructure.DTO.Models;
using Infrastructure.DTO.Private.Account;
using Microsoft.AspNetCore.Components.Forms;

public interface IAccountPrivateService
{
    Task<GetUserInfoPrivateResponseDTO> GetCurrentUserInfo();
    Task<bool> UpdateUserInfo(string firstName, string lastName);
    Task<UpdateUserImagePrivateResponseDTO> UpdateUserImage(IBrowserFile file);
    Task<List<UserInfoModelShortDTO>> SearchUsersByName(string search);
    Task<List<UserInfoModelShortDTO>> GetSharedUsers();
    Task<bool> AddSharedUser(int userId);
    Task<bool> DeleteSharedUser(int sharedUserId);
}
