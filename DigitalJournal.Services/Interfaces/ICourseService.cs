using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalJournal.Domain;

namespace DigitalJournal.Services.Interfaces
{
    public interface ICourseService
    {
        public Task<IEnumerable<Module>> GetCourseModulesAsync(int courseId);
        public Task<IEnumerable<Course>> GetUserCourses(int userId);
    }
}