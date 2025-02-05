using AutoMapper;
using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Models.Identity;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.ServicesImplementation
{
    public class DoctorServices : IDoctorServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public DoctorServices(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DoctorDTO>> GetAllDoctorsAsync(Filter filter)
        {
            // Start with IQueryable<Doctor>
            var doctors = _dbContext.Doctors.AsQueryable();

            // Filter by Gender
            if (filter.Gender != null)
            {
                doctors = doctors.Where(x => x.Gender == filter.Gender.Value);
            }
            // Filter by Favorite
            else if (filter.PatientId != null)
            {
                var favoriteDoctorIds = _dbContext.PatientFavoriteDoctors
                    .Where(x => x.PatientId == filter.PatientId)
                    .Select(x => x.DoctorId);
            }
            // Filter by Rating
            else if (filter.Rate != null)
            {
                doctors = doctors.Where(d => d.Reviews.Any(r => r.Rating >= 5));
            }
            // Sorting by Name (A-Z or Z-A)
            doctors = filter.OrderType == "DESC"
                ? doctors.OrderByDescending(o => o.User.Name)
                : doctors.OrderBy(o => o.User.Name);

            var doctorDTO = await doctors.Select(d => new DoctorDTO
            {
                Id = d.Id,
                DoctorName = d.User.Name,
                SpecializationName = d.Specialization.Name,
                Photo = d.User.Photo

            }).ToListAsync();

            return doctorDTO;
        }

        public async Task<DoctorDetailsDto> GetDoctorDetailsAsync(int doctorId)
        {
            var doctor = await _dbContext.Doctors
                       .Include(d => d.AvailableAppointments)
                       .Include(d => d.Specialization)
                       .Include(d => d.User)
                       .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null)
                return null;
            var doctorMapping = _mapper.Map<DoctorDetailsDto>(doctor);
            return doctorMapping;
        }
    }
}
