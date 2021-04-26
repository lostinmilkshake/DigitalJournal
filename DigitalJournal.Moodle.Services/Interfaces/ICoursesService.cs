using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services.Interfaces
{
    public interface ICoursesService
    {
        public Task<IEnumerable<Course>> GetEnrolledCoursesAsync(int userId);

        public Task<IEnumerable<Section>> GetCourseContentsAsync(int courseId);
        
        public Task<IEnumerable<Module>> GetCourseModulesAsync(int courseId);
    }
}