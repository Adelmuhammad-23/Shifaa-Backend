using ShifaaAPI.Enums;

namespace ShifaaAPI.DTO
{
    public class UpdateBookingDTO
    {
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }

    }
}
