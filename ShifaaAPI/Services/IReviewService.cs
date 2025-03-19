using ShifaaAPI.DTO;
using ShifaaAPI.Models;

namespace ShifaaAPI.Services
{
    public interface IReviewService
    {
       Task<bool> AddReviewAsync(ReviewDTO dto);
        Task<List<GetReviewsByDrDTO>> GetReviewsByDrAsync(int doctorId);
       Task<List<ReviewsDetialDTO>> GetAllReviewsAsync();
    }
}
