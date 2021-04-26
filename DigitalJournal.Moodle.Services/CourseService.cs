using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services
{
    public class CourseService
    {
        private readonly MoodleHttpClientService _moodleHttpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CourseService(MoodleHttpClientService moodleHttpClientService)
        {
            _moodleHttpClientService = moodleHttpClientService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        
        public async Task<IEnumerable<Course>> GetEnrolledCoursesAsync(int userId)
        {
            // TODO: Move json to HttpClientService
            var query = $"&wsfunction=core_enrol_get_users_courses&userid={userId}";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(_moodleHttpClientService.MoodleUrl + query);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Course>>(result, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Section>> GetCourseContentsAsync(int courseId)
        {
            var query = $"&wsfunction=core_course_get_contents&courseid={courseId}";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(_moodleHttpClientService.MoodleUrl + query);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Section>>(result, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Module>> GetCourseModulesAsync(int courseId)
        {
            var courseSections = await GetCourseContentsAsync(courseId);
            return courseSections.SelectMany(cs => cs.Modules);
        }
    }
}