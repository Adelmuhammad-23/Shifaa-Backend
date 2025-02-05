using ShifaaAPI.Enums;

namespace ShifaaAPI.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string SpecializationName { get; set; }
        public byte[]? Photo { get; set; } 

    }

    public class DrDataDTO : DoctorDTO
    {
        public string Address { get; set; }
        public string Experience { get; set; }
        public DateOnly Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

    }
}
