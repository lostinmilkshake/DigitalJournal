using System.Threading.Tasks;
using DigitalJournal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController: ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService) => _moduleService = moduleService;

        [HttpGet("{moduleId}")]
        public async Task<IActionResult> GetModuleAsync(int moduleId)
        {
            var module = await _moduleService.GetModuleAsync(moduleId);

            return Ok(module);
        }
    }
}