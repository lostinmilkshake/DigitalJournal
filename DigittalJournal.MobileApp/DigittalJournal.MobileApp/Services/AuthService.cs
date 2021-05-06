using DigitalJournal.Domain;
using DigittalJournal.MobileApp.Models;
using DigittalJournal.MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigittalJournal.MobileApp.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public async Task<User> LogInUser(AuthUserModel authUserModel)
        {
            var result = await _httpClient.PostAsJsonAsync("/User", authUserModel);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var resultString = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(resultString, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }

        public async Task LogoutUser()
        {
            await _httpClient.PostAsync("/User/logout", null);
        }
    }
}
