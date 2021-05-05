using DigitalJournal.Domain;
using MvvmHelpers.Commands;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using DigittalJournal.MobileApp.Services.Interfaces;
using DigittalJournal.MobileApp.Views;
using DigittalJournal.MobileApp.Models;

namespace DigittalJournal.MobileApp.ViewModels
{
    public class CoursesViewModel : BaseViewModel
    {
        private CourseModel _selectedCourse;

        public ObservableCollection<CourseModel> Courses { get; set; }

        public AsyncCommand LoadCoursesCommand { get; }
        public AsyncCommand<CourseModel> CourseTapped { get; }

        private readonly ICourseService _courseService;
        private readonly IModuleService _moduleService;

        public CoursesViewModel()
        {
            Courses = new ObservableCollection<CourseModel>();
            LoadCoursesCommand = new AsyncCommand(ExecuteLoadCoursesCommand);

            _courseService = DependencyService.Get<ICourseService>();
            _moduleService = DependencyService.Get<IModuleService>();

            CourseTapped = new AsyncCommand<CourseModel>(OnCourseSelected);
        }

        public CourseModel SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                SetProperty(ref _selectedCourse, value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCourse = null;
        }

        async Task ExecuteLoadCoursesCommand()
        {
            IsBusy = true;
            Courses.Clear();

            try
            {
                var courses = await _courseService.GetCourses();

                foreach (var course in courses)
                {
                    var modules = await _moduleService.GetCourseModules(course.Id);

                    Courses.Add(new CourseModel
                    {
                        Course = course,
                        AmmountOfModules = modules.Count()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task OnCourseSelected(CourseModel course)
        {
            if (course == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ModulesPage)}?{nameof(ModulesViewModel.CourseId)}={course.Course.Id}");
        }
    }
}
