using DigitalJournal.Domain;
using DigittalJournal.MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigittalJournal.MobileApp.Services
{
    public class TaskResultService : BaseService, ITaskResultService
    {
        public async Task<TaskResult> GetTaskResultAsync(int moduleId)
        {
            var result = await _httpClient.GetStringAsync($"/TaskResult/{moduleId}");

            return result != "" ? JsonSerializer.Deserialize<TaskResult>(result, _jsonSerializerOptions) : null;
        }
    }
}
