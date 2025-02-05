namespace ShifaaAPI.DTO
{
    public class DoctorDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }
        public string ProfileImage { get; set; }
        public string Focus { get; set; }
        public IEnumerable<AvailableAppointmentDto> AvailableAppointments { get; set; }
    }

    public class AvailableAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Time { get; set; }
    }
}
