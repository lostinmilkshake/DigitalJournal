using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DigitalJournal.MobileApp.Services
{
    public class CourseService
    {
        private readonly string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "https://localhost:5001/";
        private readonly HttpClient _httpClient;

        public CourseService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

    }
}
