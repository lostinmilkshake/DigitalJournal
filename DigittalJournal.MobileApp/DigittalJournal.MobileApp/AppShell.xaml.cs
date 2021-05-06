using DigittalJournal.MobileApp.ViewModels;
using DigittalJournal.MobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DigittalJournal.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CoursesPage), typeof(CoursesPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(ModulesPage), typeof(ModulesPage));
        }

        protected override async void OnAppearing()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}
