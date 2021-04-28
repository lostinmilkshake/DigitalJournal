using AutoMapper;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Services
{
    public class MoodleModuleProfile : Profile
    {
        public MoodleModuleProfile()
        {
            CreateMap<Module, Domain.Module>().ForMember(m => m.Type,
                    x => x.MapFrom(m => m.ModName))
                .ForMember(m => m.TypeId,
                    x => x.MapFrom(m => m.Instance)).
                ForMember(m => m.CourseId, x => x.MapFrom(m => m.Course))
                .ForMember(m => m.MaxGrade, x => x.MapFrom(m => m.Grade));
        }
    }
}