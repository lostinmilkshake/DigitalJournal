using System.Threading.Tasks;
using AutoMapper;
using DigitalJournal.Domain;
using DigitalJournal.Moodle.Services.Interfaces;

namespace DigitalJournal.Services
{
    public class ModuleService : Interfaces.IModuleService
    {
        private readonly IModuleService _moodleModuleService;
        private readonly IMapper _mapper;

        public ModuleService(IModuleService moodleModuleService, IMapper mapper)
        {
            _moodleModuleService = moodleModuleService;
            _mapper = mapper;
        }

        public async Task<Module> GetModuleAsync(int moduleId)
        {
            var moodleModule = await _moodleModuleService.GetModuleAsync(moduleId);
            return _mapper.Map<Module>(moodleModule);
        }
    }
}