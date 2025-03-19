using ShifaaAPI.DTO;
using ShifaaAPI.Models.Identity;

namespace ShifaaAPI.Services
{
    public interface IProfileService
    {
      
            Task<UserProfileDTO> GetProfileAsync(int id);
            Task<bool> UpdateProfileAsync(UpdateUserProfileDTO updatedProfile, int id);
            Task<bool> ChangePasswordAsync(int id , ChangePasswordDTO passDTO);
    }
}
