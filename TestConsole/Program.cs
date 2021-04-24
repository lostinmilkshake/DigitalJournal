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
            var userService = new UserService(moodle);

            var result = await userService.GetEnrolledCoursesAsync(2);
            
        }
    }
}