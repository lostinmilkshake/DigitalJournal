using System;
using System.Threading.Tasks;
using AutoMapper;
using DigitalJournal.Domain;
using DigitalJournal.Moodle.Domain;
using DigitalJournal.Moodle.Domain.Enum;
using DigitalJournal.Moodle.Services.Interfaces;
using DigitalJournal.Services.Interfaces;
using IModuleService = DigitalJournal.Services.Interfaces.IModuleService;

namespace DigitalJournal.Services
{
    public class TaskResultService : ITaskResultService
    {
        private readonly IGradeService _moodleGradeService;
        private readonly IModuleService _moduleService;
        private readonly IMapper _mapper;

        public TaskResultService(IGradeService moodleGradeService, IModuleService moduleService, IMapper mapper)
        {
            _moodleGradeService = moodleGradeService;
            _moduleService = moduleService;
            _mapper = mapper;
        }

        public async Task<TaskResult> GetTaskResult(int moduleId, int userId)
        {
            var module = await _moduleService.GetModuleAsync(moduleId);

            try
            {
                var gradeForTask = module.Type switch
                {
                    nameof(TaskTypes.assign) =>
                        await _moodleGradeService.GetAssignmentGradeAsync(module.TypeId, userId),
                    nameof(TaskTypes.quiz) => await _moodleGradeService.GetQuizGradeAsync(module.TypeId, userId),
                    _ => null
                };
                return gradeForTask != null ? _mapper.Map<TaskResult>(gradeForTask) : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}