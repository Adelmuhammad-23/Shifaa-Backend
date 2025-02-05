using System.ComponentModel.DataAnnotations.Schema;

namespace ShifaaAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
