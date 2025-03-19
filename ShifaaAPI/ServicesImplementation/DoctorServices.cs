using AutoMapper;
using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Models;
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
                   .Select(x => x.DoctorId).ToList();
                doctors = doctors.Where(d => favoriteDoctorIds.Contains(d.Id));
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
                Email = d.User.Email,
                SpecializationName = d.Specialization.Name,
                Photo = d.User.Photo,
                Address = d.Address,
                Experience = d.Experience,
                Phone = d.User.PhoneNumber
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

        public async Task<bool> AddToFavoriteAsync(FavoriteDrDTO dto)
        {
            var exist = await _dbContext.PatientFavoriteDoctors
                .AnyAsync(e => e.PatientId == dto.PatientId && e.DoctorId == dto.DoctorId);
            if (exist)
                return false;
            var favorite = new PatientFavoriteDoctors
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId
            };
            _dbContext.PatientFavoriteDoctors.Add(favorite);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveFromFavoriteAsync(FavoriteDrDTO dto)
        {
            var favorite = await _dbContext.PatientFavoriteDoctors
                .Where(f => f.PatientId == dto.PatientId && f.DoctorId == dto.DoctorId).FirstOrDefaultAsync();
            if (favorite == null)
                return false;
            _dbContext.Remove(favorite);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<string> CreateDoctorAsync(CreateDoctoDTO doctorDTO)
        {
            var defaultPassword = "1234";
            var specialization = await _dbContext.Specializations.FirstOrDefaultAsync(s => s.Name == doctorDTO.SpecializationName);
            if (specialization == null)
                return "this specialization not found";
            var user = new User
            {
                Email = doctorDTO.Email,
                Name = doctorDTO.DoctorName,
                RoleId = 2,
                Password = defaultPassword
            };
            if (doctorDTO.Image != null)
            {
                using var dataStream = new MemoryStream();
                await doctorDTO.Image.CopyToAsync(dataStream);
                user.Photo = dataStream.ToArray();
            }

            if (user == null)
                return "Failed to create doctor";
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var doctor = new Doctor
            {
                Id = user.Id,
                User = user,
                Address = doctorDTO.Address,
                Experience = doctorDTO.Experience,
                Specialization = specialization
            };

            _dbContext.Doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
            var userRole = new IdentityUserRole<int>
            {
                UserId = user.Id,
                RoleId = 2 
            };
            _dbContext.UserRoles.Add(userRole);
            await _dbContext.SaveChangesAsync();
            return $"Doctor created successfully. Default password: {defaultPassword}";

        }
        public async Task<bool> RemoveDoctorAsync(int doctorId)
        {
            var doctor = await _dbContext.Doctors.FindAsync(doctorId);
            if (doctor == null)
                return false;

            var user = await _dbContext.Users
                .Include(u => u.Doctor)
                .FirstOrDefaultAsync(u => u.Doctor.Id == doctorId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }

            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
