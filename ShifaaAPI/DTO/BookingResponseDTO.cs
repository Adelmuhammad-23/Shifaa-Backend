using Swashbuckle.AspNetCore.Annotations;

namespace ShifaaAPI.DTO
{
    public class BookingResponseDTO
    {
        [SwaggerSchema("Success message")]
        public string Message { get; set; }

        [SwaggerSchema("Generated Booking ID")]
        public int BookingId { get; set; }

        [SwaggerSchema("Booking details")]
        public CreateBookingDTO Data { get; set; }
    }
}
