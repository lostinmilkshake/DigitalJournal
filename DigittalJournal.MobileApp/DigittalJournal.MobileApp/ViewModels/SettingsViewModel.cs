using DigittalJournal.MobileApp.Services.Interfaces;
using DigittalJournal.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigittalJournal.MobileApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        public Command LogoutCommand { get; }

        public SettingsViewModel()
        {
            _authService = DependencyService.Get<IAuthService>();
            LogoutCommand = new Command(OnLogoutClicked);
        }

        private async void OnLogoutClicked(object obj)
        {
            IsBusy = true;

            await _authService.LogoutUser();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

            IsBusy = false;
        }
    }
}
