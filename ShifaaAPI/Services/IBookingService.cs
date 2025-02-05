namespace ShifaaAPI.Services
{
    using ShifaaAPI.DTO;
    using ShifaaAPI.Models;

    public interface IBookingService
    {
        Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId);
        Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto);

    }


}
