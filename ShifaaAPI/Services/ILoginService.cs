using ShifaaAPI.Models.Identity;

namespace ShifaaAPI.Services
{
    public interface ILoginService
    {
        public Task<string> LogUserAsync(string email, string password);
    }
}
