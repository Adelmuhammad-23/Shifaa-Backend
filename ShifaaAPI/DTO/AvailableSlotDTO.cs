namespace ShifaaAPI.DTO
{
    public class AvailableSlotDTO
    {
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
        public int AppointmentId { get; set; }
    }
}
