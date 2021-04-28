using AutoMapper;

namespace DigitalJournal.Services
{
    public class MoodleCourseProfile : Profile
    {
        public MoodleCourseProfile()
        {
            CreateMap<Moodle.Domain.Course, Domain.Course>();
        }
    }
}