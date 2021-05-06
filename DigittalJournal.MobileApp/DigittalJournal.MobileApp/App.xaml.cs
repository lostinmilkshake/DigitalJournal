using DigittalJournal.MobileApp.Services;
using DigittalJournal.MobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigittalJournal.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<CourseService>();
            DependencyService.Register<ModuleService>();
            DependencyService.Register<TaskResultService>();
            DependencyService.RegisterSingleton(new AuthService());
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
