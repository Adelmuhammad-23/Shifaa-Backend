using ShifaaAPI.Services;

using ShifaaAPI.ServicesImplementation;
using System.Reflection;

namespace ShifaaAPI
{


    public static class Dependencis
    {
        public static IServiceCollection AddDependencis(this IServiceCollection services)
        {

            //Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IRegisterServies, RegisterServies>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IDoctorServices, DoctorServices>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IChatService, ChatService>();


            return services;
        }

    }
}
