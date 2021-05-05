using System.Threading.Tasks;
using DigitalJournal.Services;
using DigitalJournal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalJournal.Web.Controllers
{
    public class BaseAuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public BaseAuthController(IUserService userService)
        {
            _userService = userService;
        }

        protected async Task<Domain.User> GetLoggedInUser()
        {
            var userName = AuthService.GetLoggedInUser();

            return userName == null ? null : await _userService.GetUserAsync(userName);
        }
    }
}