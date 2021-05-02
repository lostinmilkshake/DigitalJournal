using System.Threading.Tasks;
using DigitalJournal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskResultController : BaseAuthController
    {
        private readonly ITaskResultService _taskResultService;

        public TaskResultController(ITaskResultService taskResultService, IUserService userService) : base(userService)
        {
            _taskResultService = taskResultService;
        }

        [HttpGet("{moduleId}/{userId}")]
        public async Task<IActionResult> GetTaskResult(int moduleId, int userId)
        {
            var taskResult = await _taskResultService.GetTaskResult(moduleId, userId);

            return Ok(taskResult);
        }
        
        [HttpGet("{moduleId}")]
        public async Task<IActionResult> GetTaskResult(int moduleId)
        {
            var currentUser = await GetLoggedInUser();
            var taskResult = await _taskResultService.GetTaskResult(moduleId, currentUser.Id);

            return Ok(taskResult);
        }
    }
}