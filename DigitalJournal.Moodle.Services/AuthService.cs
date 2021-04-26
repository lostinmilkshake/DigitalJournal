using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;
using DigitalJournal.Moodle.Services.Interfaces;

namespace DigitalJournal.Moodle.Services
{
    public class AuthService : IAuthService
    {
        public async Task<AuthResponse> Login(string username, string password)
        {
            var query =
                $"http://localhost:80/login/token.php?username={username}&password={password}&service=moodle_mobile_app";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AuthResponse>(result);
        }
    }
}