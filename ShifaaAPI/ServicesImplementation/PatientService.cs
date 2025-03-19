using ShifaaAPI.DTO;
using ShifaaAPI.Models;
using ShifaaAPI.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShifaaAPI.Services;

namespace ShifaaAPI.ServicesImplementation
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            return await _dbContext.Patients
                .Select(p => new PatientDTO
                {
                    Id = p.Id,
                    Name = p.patientName, 
                    Age = p.Age,
                    Email = p.User.Email, 
                    Phone = p.User.PhoneNumber 
                })
                .ToListAsync();
        }
    }
}