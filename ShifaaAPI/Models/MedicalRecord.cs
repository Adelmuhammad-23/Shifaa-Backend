using System.ComponentModel.DataAnnotations.Schema;

namespace ShifaaAPI.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public required string Diagnosis { get; set; }
        public required string Treatment { get; set; }
        public virtual Booking Booking { get; set; }

    }
}
