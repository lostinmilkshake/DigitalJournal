using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services
{
    public class ModuleService
    {
        private readonly MoodleHttpClientService _moodleHttpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ModuleService(MoodleHttpClientService moodleHttpClientService)
        {
            _moodleHttpClientService = moodleHttpClientService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Module> GetModuleAsync(int moduleId)
        {
            var query = $"&wsfunction=core_course_get_course_module&cmid={moduleId}";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(_moodleHttpClientService.MoodleUrl + query);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CourseModule>(result, _jsonSerializerOptions).Module;
        }
    }
}