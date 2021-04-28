using Microsoft.Extensions.DependencyInjection;

namespace DigitalJournal.Services
{
    public static class AutoMapperMoodleConfigure
    {
        public static void AddMoodleAutoMapper(this IServiceCollection servicec)
        {
            servicec.AddAutoMapper(typeof(MoodleModuleProfile), typeof(MoodleCourseProfile), typeof(MoodleUserProfile));
        }
    }
}