using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Enums;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.ServicesImplementation
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId)
        {
            var availableSlots = await _dbContext.AvailableAppointments
                .Where(a => a.DoctorId == doctorId && a.IsAvailable)
                .Select(a => new AvailableSlotDTO
                {
                    Time = a.Time,
                    AppointmentId = a.Id
                })
                .ToListAsync();

            return availableSlots;
        }

        public async Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto)
        {
            var appointment = await _dbContext.AvailableAppointments
                .FirstOrDefaultAsync(a => a.Id == bookingDto.AppointmentId && a.IsAvailable);

            if (appointment == null)
            {
                return null;
            }

            var booking = new Booking
            {
                AppointmentId = appointment.Id,
                Status = BookingStatus.New,
                Date = appointment.Time,
                PatientId = bookingDto.PatientId,
                DoctorId = appointment.DoctorId,
                ProblemDescription = bookingDto.ProblemDescription
            };

            appointment.IsAvailable = false;

            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();

            return booking;
        }
    }
}

