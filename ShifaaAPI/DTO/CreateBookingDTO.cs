using ShifaaAPI.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ShifaaAPI.DTO
{

    public class CreateBookingDTO
    {
        [SwaggerSchema("Doctor ID for the appointment Example = 5")]
        public int doctorId { get; set; }

        [SwaggerSchema("Appointment day Example = 2025-02-10")]
        public DateOnly day { get; set; }

        [SwaggerSchema("Appointment time Example = 15:30:00")]
        public TimeOnly time { get; set; }

        [SwaggerSchema("Patient name (if booking for someone else , Example = ohn Doe")]
        public string? patientName { get; set; }

        [SwaggerSchema("Patient gender Example = Male")]
        public string gender { get; set; }

        [SwaggerSchema("Patient age Example = 25")]
        public decimal Age { get; set; }

        [SwaggerSchema("Is the appointment for the patient themselves? Example = true")]
        public bool ForHimSelf { get; set; }

        [SwaggerSchema("Patient ID Example = 123")]
        public int PatientId { get; set; }

        [SwaggerSchema("Description of the patient's problem Example = Fever and headache")]
        public string ProblemDescription { get; set; }
    }

    public class GetBookingDTO
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string patientName { get; set; }
        public int DoctorId { get; set; }
        public int BookingId { get; set; }
        public BookingStatus Status { get; set; }
        public string SpecializationName { get; set; }
        public string? Photo { get; set; }
        public DateOnly Day { get; set; }
        public string Time { get; set; }
        public string Address { get; set; }

    }
    public class AllBookingDTO
    {
       // public int Id { get; set; }
        public string DoctorName { get; set; }
        public string patientName { get; set; }
        //public int DoctorId { get; set; }
        //public int BookingId { get; set; }
        public String Status { get; set; }
        //public string SpecializationName { get; set; }
        //public string? Photo { get; set; }
        public DateOnly Day { get; set; }
        public string Time { get; set; }
        //public string Address { get; set; }

    }
    public class FilterBookingDTO
    {
        public int PatientId { get; set; }
    }

}
