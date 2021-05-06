﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DigittalJournal.MobileApp.Services
{
    public class BaseService
    {
        // TODO: Change BaseUrl
        private string BaseUrl = "http://b0f46aa35be8.ngrok.io/";

        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaseService()
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
    }
}