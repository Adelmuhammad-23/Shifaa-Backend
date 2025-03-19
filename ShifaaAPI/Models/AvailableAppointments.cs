namespace ShifaaAPI.Models
{
    public class AvailableAppointments
    {
        public int Id { get; set; } // Primary Key
        public DateOnly Day { get; set; } // Time of the appointment
        public TimeOnly Time { get; set; } // Time of the appointment
        public bool IsAvailable { get; set; } // Indicates if the slot is available

        // Relationships
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
