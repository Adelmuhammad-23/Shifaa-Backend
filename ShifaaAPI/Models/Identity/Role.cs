using Microsoft.AspNetCore.Identity;

namespace ShifaaAPI.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public static string PatientRole = "Patient";
        public static string DoctorRole = "Doctor";
    }
}
