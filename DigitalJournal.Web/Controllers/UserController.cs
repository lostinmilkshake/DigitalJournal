using System.Threading.Tasks;
using DigitalJournal.Domain;
using DigitalJournal.Services;
using DigitalJournal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseAuthController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base(userService) => _userService = userService;

        [HttpPost]
        public async Task<IActionResult> LogInUser(string userName, string password)
        {
            await AuthService.Login(userName, password);

            var user = await GetLoggedInUser();

            return user == null ? (IActionResult) NotFound() : Ok(user);
        }
        
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserAsync(string userName)
        {
            var user = await _userService.GetUserAsync(userName);

            return Ok(user);
        }
    }
}