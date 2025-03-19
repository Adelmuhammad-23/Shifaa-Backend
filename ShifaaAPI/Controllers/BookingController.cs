using ShifaaAPI.AppMetaData;
using ShifaaAPI.DTO;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Description = "Allows a patient to book an appointment with a doctor based on availability !(Note : if the appointment for the patient themselves delete PatientName From Request )."
        )]
        [SwaggerResponse(200, "Appointment booked successfully", typeof(BookingResponseDTO))]
        [SwaggerResponse(400, "The selected appointment is not available")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateBookingDTO bookingDto)
        {
            var booking = await _bookingService.BookAppointmentAsync(bookingDto);
            if (booking == null)
            {
                return BadRequest(new { message = "The selected appointment is not available." });
            }
            return Ok(new BookingResponseDTO
            {
                Message = "Appointment booked successfully.",
                BookingId = booking.Id,
                Data = bookingDto
            });
        }

        [HttpPut(Router.BookingRouting.UpdateBooking)]
        public async Task<IActionResult> UpdateBooking(int bookingId ,UpdateBookingDTO dto)
        {
            var message = await _bookingService.UpdateBookingAsync(bookingId, dto);
            if(message.Contains("not found") ||message.Contains( "already canceled")) 
                return BadRequest(message);
            if(message.Contains("exceeding allowed changes"))
                return BadRequest(message);
            return Ok(message);

        }


        //[HttpDelete(Router.BookingRouting.CancelAppointment)]
        //public async Task<IActionResult> CancelAppointment(int id)
        //{
        //    var result = await _bookingService.CancelBookingAsync(id);
        //    if (!result) return BadRequest(new { message = "The appointment not available " });
        //    return Ok(new { message = "Appointment has been cancelled" });
        //}

        [HttpGet(Router.BookingRouting.AllBooking)]
        public async Task<IActionResult> GetAllBookingByPatientId(int patientId)
        {
            var bookings = await _bookingService.GetBookingByPatientIdAsync(patientId);
            if (bookings == null) return BadRequest("Not found any booking");
            return Ok(bookings);
        }
        [HttpGet(Router.BookingRouting.GetAllBookings)]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
    }
}