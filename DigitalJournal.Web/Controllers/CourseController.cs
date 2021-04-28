using System.Threading.Tasks;
using DigitalJournal.Services;
using DigitalJournal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _coursesService;

        public CourseController(ICourseService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet("course-modules/{courseId}")]
        public async Task<IActionResult> GetCourseModules(int courseId)
        {
            var courseModules = await _coursesService.GetCourseModulesAsync(courseId);

            return Ok(courseModules);
        }
        
        [HttpGet("user-courses/{userId}")]
        public async Task<IActionResult> GetUserCourses(int userId)
        {
            var courseModules = await _coursesService.GetUserCourses(userId);

            return Ok(courseModules);
        }
    }
}