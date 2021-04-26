using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services
{
    public class UserService
    {
        private readonly MoodleHttpClientService _moodleHttpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public UserService(MoodleHttpClientService moodleHttpClientService)
        {
            _moodleHttpClientService = moodleHttpClientService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<User>> GetUserAsync()
        {
            var query = "wsfunction=core_user_get_users&moodlewsrestformat=json&criteria[0][key]=email&criteria[0][value]=demo";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<User>>(result);
        }
    }
}