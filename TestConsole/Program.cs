using System;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Services;

namespace TestConsole
{
    public static class Program
    {
        public static async Task Main()
        {
            var moodle = new MoodleHttpClientService();
            var courseService = new CourseService(moodle);
            var moduleService = new ModuleService(moodle);
            var gradeService = new GradeService(moodle);

            var result = await courseService.GetEnrolledCoursesAsync(2);
            var moduleRes = await moduleService.GetModuleAsync(6);
            var rese = await courseService.GetCourseModulesAsync(2);
            var jhhhh = await gradeService.GetAssignmentGradeAsync(1, 3);
            var jjj = await gradeService.GetQuizGradeAsync(1, 3);
        }
    }
}