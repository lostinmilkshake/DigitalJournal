using DigitalJournal.Domain;
using DigittalJournal.MobileApp.Models;
using DigittalJournal.MobileApp.Services.Interfaces;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace DigittalJournal.MobileApp.ViewModels
{
    [QueryProperty(nameof(CourseId), nameof(CourseId))]
    public class ModulesViewModel : BaseViewModel
    {
        public ObservableCollection<ModulesResults> Modules { get; set; }
        public AsyncCommand LoadModulesCommand { get; }
        private readonly IModuleService _moduleService;
        private readonly ITaskResultService _taskResultService;
        private int courseId;

        public ModulesViewModel()
        {
            Modules = new ObservableCollection<ModulesResults>();
            _moduleService = DependencyService.Get<IModuleService>();
            _taskResultService = DependencyService.Get<ITaskResultService>();
        }

        public int CourseId
        {
            get => courseId;
            set
            {
                courseId = value;
                LoadModulesAsync(value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async void LoadModulesAsync(int courseId)
        {
            IsBusy = true;
            Modules.Clear();

            try
            {
                var modules = await _moduleService.GetCourseModules(courseId);

                foreach (var module in modules)
                {
                    var taskResult = await _taskResultService.GetTaskResultAsync(module.Id);
                    Modules.Add(new ModulesResults
                    {
                        Module = module,
                        TaskResult = taskResult
                    });
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
