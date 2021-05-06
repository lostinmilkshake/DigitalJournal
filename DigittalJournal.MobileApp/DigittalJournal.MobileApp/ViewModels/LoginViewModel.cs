using DigittalJournal.MobileApp.Models;
using DigittalJournal.MobileApp.Services.Interfaces;
using DigittalJournal.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigittalJournal.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public AuthUserModel AuthUserModel { get; set; }
        private readonly IAuthService _authService;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            _authService = DependencyService.Get<IAuthService>();
            AuthUserModel = new AuthUserModel();

            // TODO: Remove someday
            AuthUserModel.Username = "student";
            AuthUserModel.Password = "Aa-123456";
        }

        private async void OnLoginClicked(object obj)
        {
            IsBusy = true;

            var user = await _authService.LogInUser(AuthUserModel);
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (user != null)
            {
                await Shell.Current.GoToAsync($"//{nameof(CoursesPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Incorrect Credentials", "Inccorect Username or Password", "Ok");
            }

            IsBusy = false;
        }
    }
}
