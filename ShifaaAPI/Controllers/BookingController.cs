using ShifaaAPI.AppMetaData;
using ShifaaAPI.DTO;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShifaaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet(Router.BookingRouting.GetAvailableSlots)]
        public async Task<IActionResult> GetAvailableSlots(int doctorId)
        {
            var availableSlots = await _bookingService.GetAvailableSlotsAsync(doctorId);

            if (availableSlots == null || availableSlots.Count == 0)
            {
                return NotFound(new { message = "No available slots for this date." });
            }
            return Ok(availableSlots);
        }

        [HttpPost(Router.BookingRouting.BookAppointment)]
        public async Task<IActionResult> BookAppointment([FromBody] CreateBookingDTO bookingDto)
        {
            var booking = await _bookingService.BookAppointmentAsync(bookingDto);

            if (booking == null)
            {
                return BadRequest(new { message = "The selected appointment is not available." });
            }

            return Ok(new { message = "Appointment booked successfully.", data = booking });
        }
    }
}