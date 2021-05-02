using DigitalJournal.Domain;
using DigittalJournal.MobileApp.Services;
using MvvmHelpers.Commands;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigittalJournal.MobileApp.ViewModels
{
    public class CoursesViewModel : BaseViewModel
    {
        public ObservableCollection<Course> Courses { get; set; }
        public AsyncCommand LoadCoursesCommand { get; }
        public ICourseService CourseService;

        public CoursesViewModel()
        {
            Courses = new ObservableCollection<Course>();
            LoadCoursesCommand = new AsyncCommand(ExecuteLoadCoursesCommand);
            CourseService = DependencyService.Get<ICourseService>();
        }

        internal void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadCoursesCommand()
        {
            IsBusy = true;

                Courses.Clear();
                var courses = await CourseService.GetCourses();

                foreach (var course in courses)
                {
                    Courses.Add(course);
                }

            IsBusy = false;
        }
    }
}
