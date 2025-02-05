namespace ShifaaAPI.DTO
{
    public class CreateBookingDTO
    {
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public string ProblemDescription { get; set; }
    }
}
