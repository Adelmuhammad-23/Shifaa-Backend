using AutoMapper;

namespace ShifaaAPI.Mapping.DoctorMapping
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            GetDoctorDetailsMapping();
        }
    }
}
