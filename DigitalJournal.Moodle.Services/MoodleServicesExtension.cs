using DigitalJournal.Moodle.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalJournal.Moodle.Services
{
    public static class MoodleServicesExtension
    {
        public static void AddModuleServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICoursesService, CourseService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<MoodleHttpClientService>();
        }
    }
}