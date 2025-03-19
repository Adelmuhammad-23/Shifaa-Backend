namespace ShifaaAPI.DTO
{
    public class CreateDoctoDTO
    {
        public string DoctorName { get; set; }
        public string SpecializationName { get; set; }
        public string Experience { get; set; }
        public string Email { get; set; }
        public IFormFile? Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
