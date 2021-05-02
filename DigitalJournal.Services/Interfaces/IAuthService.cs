using System.Threading.Tasks;
using DigitalJournal.Domain;

namespace DigitalJournal.Services.Interfaces
{
    public interface IAuthService
    {
        public Task Login(string username, string password);
        public User GetLoggedInUser();
    }
}