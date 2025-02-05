using ShifaaAPI.AppMetaData;
using ShifaaAPI.DTO;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShifaaAPI.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorServices _drServices;
        #region Constructor
        public DoctorsController(IDoctorServices drServices)
        {
            _drServices = drServices;
        }
        #endregion
        #region End point

        [HttpGet(Router.DoctorsRouting.GetList)]
        public async Task<IActionResult> GetAllDoctors([FromQuery] Filter filter)
        {
            try
            {
                var doctors = await _drServices.GetAllDoctorsAsync(filter);
                if (doctors == null || !doctors.Any())
                    return NotFound("No doctors found in the database");
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }

        }
        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctorDetails(int doctorId)
        {
            var doctor = await _drServices.GetDoctorDetailsAsync(doctorId);
            if (doctor == null)
                return NotFound("Doctor not found.");

            return Ok(doctor);
        }

        #endregion
    }
}
