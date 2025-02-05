using ShifaaAPI.Enums;

namespace ShifaaAPI.DTO
{
    public class Filter
    {
        public Gender? Gender { get; set; }
        public int? Rate { get; set; }
        public int? PatientId { get; set; }
        public string? OrderType { get; set; } = "ASC";
    }
}
