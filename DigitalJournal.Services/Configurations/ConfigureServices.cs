using DigitalJournal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalJournal.Services.Configurations
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskResultService, TaskResultService>();
        }
    }
}