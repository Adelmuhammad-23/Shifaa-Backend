using ShifaaAPI.DTO;
using ShifaaAPI.Models;

namespace ShifaaAPI.Services
{
    public interface IDoctorServices
    {
        Task<List<DoctorDTO>> GetAllDoctorsAsync(Filter filter);
        Task<DoctorDetailsDto> GetDoctorDetailsAsync(int doctorId);
        Task<bool> AddToFavoriteAsync(FavoriteDrDTO dto);
        Task<bool> RemoveFromFavoriteAsync(FavoriteDrDTO dto);
        Task<string> CreateDoctorAsync(CreateDoctoDTO doctorDTO);
        Task<bool> RemoveDoctorAsync(int doctorId);
    }
}
