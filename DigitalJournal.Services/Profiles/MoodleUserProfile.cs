using AutoMapper;

namespace DigitalJournal.Services
{
    public class MoodleUserProfile : Profile
    {
        public MoodleUserProfile()
        {
            CreateMap<Moodle.Domain.User, Domain.User>();
        }
    }
}