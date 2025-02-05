using ShifaaAPI.Enums;

namespace ShifaaAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public BookingStatus Status { get; set; }

        public DateTime Date { get; set; }

        public string ProblemDescription { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual AvailableAppointments Appointment { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
    }
}
