using System.Threading.Tasks;
using DigitalJournal.Domain;

namespace DigitalJournal.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserAsync(string userName);
    }
}