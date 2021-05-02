using DigitalJournal.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Text.Json;

namespace DigittalJournal.MobileApp.Services
{
    public class CourseService : ICourseService
    {
        // TODO: Change BaseUrl
        private string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
                                            "http://6199bd03ba95.ngrok.io" : "http://localhost:5000";

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CourseService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            var result = await _httpClient.GetStringAsync("/Course/user-courses/2");

            return JsonSerializer.Deserialize<IEnumerable<Course>>(result, _jsonSerializerOptions);
        }
    }
}
