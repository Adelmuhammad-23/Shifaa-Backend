namespace ShifaaAPI.AppMetaData
{
    // Class that defines API routing constants
    public class Router
    {
        public const string Root = "Api/";
        public const string Version = "V1/";
        public const string Rule = Root + Version;
        public static class AccountRouting
        {
            public const string Prefix = Rule + "Account/";
            public const string Register = Prefix + "Register";
            public const string Login = Prefix + "Login";
        }
        public static class DoctorsRouting
        {
            public const string Prefix = Rule + "Doctors/";
            public const string GetList = Prefix + "GetAllDoctors";
        }
        public static class BookingRouting
        {
            public const string Prefix = Rule + "Booking/";
            public const string GetAvailableSlots = Prefix + "GetAvailableSlots";
            public const string BookAppointment = Prefix + "BookAppointment";
        }
        public static class ProfileRouting
        {
            public const string Prefix = Rule + "Profile/";
            public const string GetUser = Prefix + "GetUserProfile";
            public const string UpdateUser = Prefix + "UpdateUserProfile";
        }
    }
}
