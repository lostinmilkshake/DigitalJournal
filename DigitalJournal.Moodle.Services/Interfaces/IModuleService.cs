using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services.Interfaces
{
    public interface IModuleService
    {
        public Task<Module> GetModuleAsync(int moduleId);
    }
}