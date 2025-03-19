using ShifaaAPI.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShifaaAPI.Models
{
    public class Patient
    {
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string patientName { get; set; }
        public int Age { get; set; }
        public string MedicalHistory { get; set; }
        public string? Gender { get; set; }
        public virtual User User { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Booking> Bookings { get; set; }
        public ICollection<PatientFavoriteDoctors> PatientFavoriteDoctors { get; set; }


    }
}
