using System.Threading.Tasks;
using AutoMapper;
using DigitalJournal.Domain;
using DigitalJournal.Services.Interfaces;

namespace DigitalJournal.Services
{
    public class UserService : IUserService
    {
        private readonly Moodle.Services.Interfaces.IUserService _moodleUserService;
        private readonly IMapper _mapper;

        public UserService(Moodle.Services.Interfaces.IUserService moodleUserService, IMapper mapper)
        {
            _moodleUserService = moodleUserService;
            _mapper = mapper;
        }
        
        public async Task<User> GetUserAsync(string userName)
        {
            var user = await _moodleUserService.GetUserAsync(userName);

            return _mapper.Map<User>(user);
        }
    }
}