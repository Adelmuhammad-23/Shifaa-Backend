using ShifaaAPI.AppMetaData;
using ShifaaAPI.DTO;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShifaaAPI.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
       private readonly IProfileService _profileService;
        #region Constractor
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        #endregion

        #region End Point

        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;

        [HttpGet(Router.ProfileRouting.GetUser)]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _profileService.GetProfileAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPut(Router.ProfileRouting.UpdateUser)]
        public async Task<IActionResult> UpdateUserProfile([FromForm]UpdateUserProfileDTO updatedProfile , int id)
        {
            var user = await _profileService.UpdateProfileAsync(updatedProfile ,id);
            if (user == false) return NotFound();
            if (updatedProfile.Photo != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(updatedProfile.Photo.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (updatedProfile.Photo.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");
            }
            return Ok(user);
        }
        [HttpPut("change")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordDTO dto ,int id)
        {
            var result = await _profileService.ChangePasswordAsync(id, dto);
            if(!result) return BadRequest("Password change failed");
            return Ok("Password changed successfully");
        }

        #endregion
    }
}

