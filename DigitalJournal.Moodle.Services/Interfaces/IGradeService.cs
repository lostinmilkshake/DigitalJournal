using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;

namespace DigitalJournal.Moodle.Services.Interfaces
{
    public interface IGradeService
    {
        public Task<Grades> GetAssignmentResultAsync(int assignmentId, int userId);
        public Task<Attempt> GetQuizResultAsync(int quizId, int userId);
        public Task<GradeForTask> GetAssignmentGradeAsync(int assignmentId, int userId);
        public Task<GradeForTask> GetQuizGradeAsync(int quizId, int userId);
    }
}