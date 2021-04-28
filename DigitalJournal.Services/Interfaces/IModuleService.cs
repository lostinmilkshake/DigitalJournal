using System.Threading.Tasks;
using DigitalJournal.Domain;

namespace DigitalJournal.Services.Interfaces
{
    public interface IModuleService
    {
        public Task<Module> GetModuleAsync(int moduleId);
    }
}