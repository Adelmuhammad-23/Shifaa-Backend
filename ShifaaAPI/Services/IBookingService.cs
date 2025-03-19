namespace ShifaaAPI.Services
{
    using ShifaaAPI.DTO;
    using ShifaaAPI.Models;

    public interface IBookingService
    {
        Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId);
        Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto);
        Task<string> UpdateBookingAsync(int bookingId ,UpdateBookingDTO updateDTO);
        //Task<bool> CancelBookingAsync(int id);
        Task<List<GetBookingDTO>> GetBookingByPatientIdAsync(int patientId);
        Task<List<AllBookingDTO>> GetAllBookingsAsync();

    }


}
