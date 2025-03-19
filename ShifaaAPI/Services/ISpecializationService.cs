using ShifaaAPI.DTO;
using ShifaaAPI.Models;

namespace ShifaaAPI.Services
{
    public interface ISpecializationService
    {
        Task<List<Specialization>> GetAllSpecializationsAsync();
        Task<List<DrDTO>> GetDoctorsBySpecializationIDAsync(int specializationId);
        Task<bool> AddSpecializationAsync(string name);
        Task<bool> RemoveSpecializationAsync(int specializationId);
    }
}
