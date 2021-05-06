using DigitalJournal.Domain;
using DigittalJournal.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigittalJournal.MobileApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> LogInUser(AuthUserModel authUser);
        Task LogoutUser();
    }
}
