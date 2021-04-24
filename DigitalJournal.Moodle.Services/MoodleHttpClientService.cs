using System;
using System.Net.Http;

namespace DigitalJournal.Moodle.Services
{
    public class MoodleHttpClientService
    {
        public HttpClient MoodleHttpClient { get; set; }
        public string MoodleUrl { get; set; }

        public MoodleHttpClientService()
        {
            // TODO: Move to appsettings
            var token = "ENTER_TOKEN";
            MoodleUrl = $"http://localhost:8888/moodle310/webservice/rest/server.php?wstoken={token}";
            MoodleHttpClient = new HttpClient {BaseAddress = new Uri(MoodleUrl), };
        }
    }
}