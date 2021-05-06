using DigitalJournal.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Text.Json;
using DigittalJournal.MobileApp.Services.Interfaces;

namespace DigittalJournal.MobileApp.Services
{
    public class CourseService : BaseService,  ICourseService
    {

        public CourseService()
        {
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            // TODO: Add getting user from auth service
            var result = await _httpClient.GetStringAsync("/Course/user-courses");

            return JsonSerializer.Deserialize<IEnumerable<Course>>(result, _jsonSerializerOptions);
        }
    }
}
