using System.ComponentModel.DataAnnotations;

namespace ShifaaAPI.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
    }
}
