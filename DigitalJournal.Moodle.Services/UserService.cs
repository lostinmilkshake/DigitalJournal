using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;
using DigitalJournal.Moodle.Services.Interfaces;

namespace DigitalJournal.Moodle.Services
{
    public class UserService : IUserService
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

        public async Task<User> GetUserAsync(string userName)
        {
            var query = $"&wsfunction=core_user_get_users_by_field&field=username&values[0]={userName}";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(_moodleHttpClientService.MoodleUrl + query);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<User>>(result, _jsonSerializerOptions).First();
        }
    }
}