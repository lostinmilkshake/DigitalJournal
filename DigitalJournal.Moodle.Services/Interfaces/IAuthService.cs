using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponse> Login(string username, string password);
    }
}