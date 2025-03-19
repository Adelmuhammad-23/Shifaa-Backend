namespace ShifaaAPI.DTO
{
    public class ReviewDTO
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
    public class GetReviewsByDrDTO
    {
        public string Comment { get; set; }
        public string SenderName { get; set; }

    }
    public class ReviewsDetialDTO
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
