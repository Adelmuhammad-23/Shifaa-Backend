using ShifaaAPI.DbContext;
using ShifaaAPI.Models;
using ShifaaAPI.Models.Identity;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Identity;

namespace ShifaaAPI.ServicesImplementation
{
    public class RegisterServies : IRegisterServies
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public RegisterServies(ApplicationDbContext dbContext,
                                      UserManager<User> userManager)
        {

            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<string> AddUserAsync(User user, string password)
        {
            using var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Find User Email
                var emailUser = await _userManager.FindByEmailAsync(user.Email);

                // Email is or not exist
                if (emailUser != null) return "EmailIsExist";

                // Create User
                var createUserResult = await _userManager.CreateAsync(user, password);
                if (!createUserResult.Succeeded)
                {
                    // Rollback and return error if user creation failed
                    await transact.RollbackAsync();
                    return createUserResult.Errors.FirstOrDefault()?.Description;
                }
                var newPatient = new Patient()
                {

                    Id = user.Id,
                    patientName = user.Name,
                    MedicalHistory = "",
                    Gender = "",
                };
                await _dbContext.Patients.AddAsync(newPatient);
                await _dbContext.SaveChangesAsync();

               // Add User To Role
                var addToRoleResult = await _userManager.AddToRoleAsync(user, "Patient");
                if (!addToRoleResult.Succeeded)
                {
                    // Rollback and return error if adding to role failed
                    await transact.RollbackAsync();
                    return addToRoleResult.Errors.FirstOrDefault()?.Description;
                }

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
    }
}
