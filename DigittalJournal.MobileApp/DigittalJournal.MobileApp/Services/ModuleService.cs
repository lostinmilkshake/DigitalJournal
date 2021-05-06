using DigitalJournal.Domain;
using DigittalJournal.MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigittalJournal.MobileApp.Services
{
    public class ModuleService : BaseService, IModuleService 
    {
        public ModuleService()
        {

        }

        public async Task<IEnumerable<Module>> GetCourseModules(int courseId)
        {
            var result = await _httpClient.GetStringAsync($"/Course/course-modules/{courseId}");

            return JsonSerializer.Deserialize<IEnumerable<Module>>(result, _jsonSerializerOptions);
        }
    }
}
