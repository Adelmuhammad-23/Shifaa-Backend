using ShifaaAPI.AppMetaData;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using ShifaaAPI.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShifaaAPI.Controllers
{
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _service;
        #region Constructor
        public SpecializationController(ISpecializationService service)
        {
            _service = service;
        }
        #endregion
        #region End point
        [HttpPost(Router.SpecializationRouting.AddSpecialization)]
        public async Task<IActionResult> AddSpecialization([FromQuery] string name)
        {
            var result = await _service.AddSpecializationAsync(name);
            if (result)
                return Ok("Specialization added successfully.");
            return BadRequest("Failed to add specialization.");
        }
        [HttpDelete(Router.SpecializationRouting.RemoveSpecialization)]
        public async Task<IActionResult> RemoveSpecialization(int specializationId)
        {
            try
            {
                var result = await _service.RemoveSpecializationAsync(specializationId);
                if (result)
                    return Ok("Specialization removed successfully.");
                return NotFound("Specialization not found.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }
        }

        [HttpGet(Router.SpecializationRouting.GetSpecializations)]
        public async Task<IActionResult> GetAllSpecializations ()
        {
            try
            {
                var specializations = await _service.GetAllSpecializationsAsync();
                if (specializations == null || !specializations.Any())
                    return NotFound("Not found any Specialization");
                return Ok(specializations);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }
        }

        [HttpGet(Router.SpecializationRouting.GetDoctorsBySpecializationID)]
        public async Task<IActionResult> GetAllDoctors(int specializationId)
        {
            try
            {
                var doctors = await _service.GetDoctorsBySpecializationIDAsync(specializationId);
                if (doctors == null || !doctors.Any())
                    return NotFound("Not found any doctor");
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }
        }


        #endregion
    }
}
