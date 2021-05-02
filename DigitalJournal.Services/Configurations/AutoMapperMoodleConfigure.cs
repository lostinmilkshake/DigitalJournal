using Microsoft.Extensions.DependencyInjection;

namespace DigitalJournal.Services.Configurations
{
    public static class AutoMapperMoodleConfigure
    {
        public static void AddMoodleAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MoodleModuleProfile), typeof(MoodleCourseProfile), typeof(MoodleUserProfile),
                typeof(MoodleGradeProfile));
        }
    }
}