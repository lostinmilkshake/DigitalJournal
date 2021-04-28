using System.Threading.Tasks;
using DigitalJournal.Domain;
using DigitalJournal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserAsync(string userName)
        {
            var user = await _userService.GetUserAsync(userName);

            return Ok(user);
        }
    }
}