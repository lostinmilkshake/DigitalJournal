using System;
using System.Threading.Tasks;
using DigitalJournal.Domain;
using DigitalJournal.Moodle.Services;
using DigitalJournal.Services.Interfaces;

namespace DigitalJournal.Services
{
    // TODO: Refactor this thing
    public static class AuthService  
    {
        private readonly static Moodle.Services.Interfaces.IAuthService _moodleAuthService;
        private static string LoggedInUser { get; set; }
        
        static AuthService()
        {
            _moodleAuthService = new Moodle.Services.AuthService();
        }
        
        public static async Task Login(string username, string password)
        {
            try
            {
                var authResponse = await _moodleAuthService.Login(username, password);

                if (authResponse.Token == null)
                {
                    LoggedInUser = null;
                    return;
                }
            }
            catch (Exception e)
            {
                LoggedInUser = null;
                return;
            }

            LoggedInUser =  username;
        }

        public static string GetLoggedInUser()
        {
            return LoggedInUser;
        }
    }
}