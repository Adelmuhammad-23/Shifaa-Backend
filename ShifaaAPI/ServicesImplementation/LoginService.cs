using ShifaaAPI.DbContext;
using ShifaaAPI.Models.Identity;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ShifaaAPI.ServicesImplementation
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public LoginService(ApplicationDbContext dbContext,
                                      UserManager<User> userManager)
        {

            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<int?> GetId(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);
            if (user == null)
                return null;
            return user.Id;
        }

        public async Task<string> LogUserAsync(string email, string password)
        {
            using var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Find User Email
                //var emailUser = await _userManager.FindByEmailAsync(email);
                var emailUser = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);

                // Email is or not exist
                if (emailUser == null) return "EmailIsNotExist";

                // Check Password
                var checkPassword = emailUser.Password == password;
                if (!checkPassword) return "PasswordIsNotCorrect";

                // Commit transaction if everything is successful
                await transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                // Rollback transaction in case of any exception
                await transact.RollbackAsync();
                return "Failed: " + ex.Message;
            }
        }

        public async Task StoreTokenAsync(string email, string token)
        {
            var emailUser = await _userManager.FindByEmailAsync(email);
            if (emailUser != null)
            {
                await _userManager.SetAuthenticationTokenAsync(emailUser, "JWT", "AccessToken", token);
            }
        }

        public async Task<User> getUserByEmail(string email)
        {
            try
            {
                using var transact = await _dbContext.Database.BeginTransactionAsync();
                var user = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);
                //var emailUser = await _userManager.FindByEmailAsync(email);

                if (user == null)
                    throw new Exception("User not found");
                return user;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
