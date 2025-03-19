using ShifaaAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShifaaAPI.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    }
}