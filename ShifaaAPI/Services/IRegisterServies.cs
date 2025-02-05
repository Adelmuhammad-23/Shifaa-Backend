using ShifaaAPI.Models.Identity;

namespace ShifaaAPI.Services
{
    public interface IRegisterServies
    {
        public Task<string> AddUserAsync(User user, string password);

    }
}
