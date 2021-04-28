using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserAsync(string userName);
    }
}