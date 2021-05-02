using AutoMapper;
using DigitalJournal.Domain;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Services
{
    public class MoodleGradeProfile : Profile
    {
        public MoodleGradeProfile()
        {
            CreateMap<GradeForTask, TaskResult>();
        }
    }
}