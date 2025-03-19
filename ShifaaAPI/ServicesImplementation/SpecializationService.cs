using AutoMapper;
using ShifaaAPI.DbContext;
using ShifaaAPI.DTO;
using ShifaaAPI.Models;
using ShifaaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ShifaaAPI.ServicesImplementation
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ApplicationDbContext _dbContext;
        public SpecializationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      public async Task<List<Specialization>> GetAllSpecializationsAsync()
        {
            var specializations = await _dbContext.Specializations.ToListAsync();
            return specializations;
        }

        public async Task<List<DrDTO>> GetDoctorsBySpecializationIDAsync(int specializationId)
        {
            var doctors = await _dbContext.Doctors.Where(d => d.Specialization.Id == specializationId)
                 .Select(d => new DrDTO
                 {
                     Id = d.Id,
                     DoctorName = d.User.Name,
                     Address = d.Address,
                     Photo = d.User.Photo != null ?  $"data:image/png;base64,{Convert.ToBase64String(d.User.Photo)} ": null 
                 }).ToListAsync();
            return doctors;

        }
        public async Task<bool> AddSpecializationAsync(string name)
        {
            var specialization = new Specialization
            {
                Name = name
            };

            _dbContext.Specializations.Add(specialization);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveSpecializationAsync(int specializationId)
        {
            var specialization = await _dbContext.Specializations.FindAsync(specializationId);
            if (specialization == null)
            {
                return false;
            }

            bool hasDoctors = await _dbContext.Doctors.AnyAsync(d => d.SpecializationId == specializationId);
            if (hasDoctors)
            {
                throw new InvalidOperationException("You cannot remove the specialization because it is associated with existing doctors.");
            }

            _dbContext.Specializations.Remove(specialization);
            return await _dbContext.SaveChangesAsync() > 0;
        }


    }
}
