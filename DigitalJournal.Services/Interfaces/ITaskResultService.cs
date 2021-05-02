using System.Threading.Tasks;
using DigitalJournal.Domain;

namespace DigitalJournal.Services.Interfaces
{
    public interface ITaskResultService
    {
        public Task<TaskResult> GetTaskResult(int moduleId, int userId);
    }
}