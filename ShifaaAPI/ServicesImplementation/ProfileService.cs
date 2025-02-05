using AutoMapper;
using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Models.Identity;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.ServicesImplementation
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProfileService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserProfileDTO> GetProfileAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null) return null;
            return new UserProfileDTO
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
        }
      public async Task<UserProfileDTO> UpdateProfileAsync(UserProfileDTO updatedProfile ,int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return null;
            if (updatedProfile.Photo != null)
            {
                using var dataStream = new MemoryStream();
                await updatedProfile.Photo.CopyToAsync(dataStream);
                user.Photo = dataStream.ToArray();
            }
            user.Name = updatedProfile.Name;
            user.Email = updatedProfile.Email;
            user.PhoneNumber = updatedProfile.Phone;
            await _dbContext.SaveChangesAsync();
            return updatedProfile;
        }
        public async Task<bool> ChangePasswordAsync(int id, ChangePasswordDTO passDTO)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return false;
            if (user.Password != passDTO.CurrentPassword || user.Password == passDTO.NewPassword || passDTO.NewPassword != passDTO.ConfirmNewPassword)
                return false;   
            user.Password = passDTO.NewPassword;
            _dbContext.SaveChanges();
            return true;

        }
    }
}
