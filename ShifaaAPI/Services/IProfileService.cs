using ShifaaAPI.DTO;

namespace ShifaaAPI.Services
{
    public interface IProfileService
    {
      
            public Task<UserProfileDTO> GetProfileAsync(int id);
            public Task<UserProfileDTO> UpdateProfileAsync(UserProfileDTO updatedProfile, int id);
            public Task<bool> ChangePasswordAsync(int id , ChangePasswordDTO passDTO);
    }
}
