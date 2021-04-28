using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalJournal.Domain;
using DigitalJournal.Moodle.Domain.Enum;
using DigitalJournal.Moodle.Services.Interfaces;
using DigitalJournal.Services.Interfaces;
using IModuleService = DigitalJournal.Services.Interfaces.IModuleService;

namespace DigitalJournal.Services
{
    public class CourseService : ICourseService
    {
        private readonly IModuleService _moduleService;
        private readonly ICoursesService _moodleCoursesService;
        private readonly IMapper _mapper;

        public CourseService(IModuleService moduleService, ICoursesService moodleCoursesService, IMapper mapper)
        {
            _moduleService = moduleService;
            _moodleCoursesService = moodleCoursesService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Course>> GetUserCourses(int userId)
        { 
            var userCourses =  await _moodleCoursesService.GetEnrolledCoursesAsync(userId);

            return _mapper.Map<IEnumerable<Course>>(userCourses);
        }
        
        public async Task<IEnumerable<Module>> GetCourseModulesAsync(int courseId)
        {
            // We only need assessments and quizzes cause only they can be graded
            var courseModules = await _moodleCoursesService.GetCourseModulesAsync(courseId);
            var quizAndAssesmentCourses  = courseModules.Where(cm =>
                cm.ModName == nameof(TaskTypes.assign) || cm.ModName == nameof(TaskTypes.quiz));

            foreach (var quizAndAssesmentCourse in quizAndAssesmentCourses)
            {
                var originalModule = await _moduleService.GetModuleAsync(quizAndAssesmentCourse.Id);

                quizAndAssesmentCourse.Course = courseId;
                quizAndAssesmentCourse.Grade = originalModule.MaxGrade;
            }
            
            return _mapper.Map<IEnumerable<Module>>(quizAndAssesmentCourses);
        }
    }
}