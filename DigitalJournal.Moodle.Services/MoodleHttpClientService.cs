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
            var token = "293714ef1aa568f9e9d295b34db40c23";
            MoodleUrl = $"http://localhost:80/webservice/rest/server.php?wstoken={token}&moodlewsrestformat=json";
            MoodleHttpClient = new HttpClient {BaseAddress = new Uri(MoodleUrl), };
        }
    }
}