using ShifaaAPI.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShifaaAPI.Models
{
    public class PatientFavoriteDoctors
    {
        public int Id { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient patient { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}