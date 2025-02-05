using ShifaaAPI.Enums;
using ShifaaAPI.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShifaaAPI.Models
{
    public class Doctor
    {
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Experience { get; set; }
        public int SpecializationId { get; set; }
        public string? Focus { get; set; }
        public ICollection<AvailableAppointments> AvailableAppointments { get; set; } // Available appointments

        public virtual Specialization Specialization { get; set; }
        public virtual User User { get; set; }
        public List<DoctorSchedule> Schedules { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Booking> Bookings { get; set; }
        public ICollection<PatientFavoriteDoctors> PatientFavoriteDoctors { get; set; }


    }

}
