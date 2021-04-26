using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalJournal.Moodle.Domain;
using DigitalJournal.Moodle.Domain.Enum;
using DigitalJournal.Moodle.Services.Interfaces;

namespace DigitalJournal.Moodle.Services
{
    public class GradeService : IGradeService
    {
        private readonly MoodleHttpClientService _moodleHttpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GradeService(MoodleHttpClientService moodleHttpClientService)
        {
            _moodleHttpClientService = moodleHttpClientService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        
        public async Task<Grades> GetAssignmentResultAsync(int assignmentId, int userId)
        {
            // TODO: Move json to HttpClientService
            var query = $"&wsfunction=mod_assign_get_grades&assignmentids[0]={assignmentId}";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(_moodleHttpClientService.MoodleUrl + query);
            var result = await response.Content.ReadAsStringAsync();
            var assignments = JsonSerializer.Deserialize<Root>(result, _jsonSerializerOptions).Assignments;
            return assignments.SelectMany(a => a.Grades).First(g => g.UserId == userId);
        }

        public async Task<Attempt> GetQuizResultAsync(int quizId, int userId)
        {
            var query = $"&wsfunction=mod_quiz_get_user_attempts&quizid={quizId}&userid={userId}";
            var response = await _moodleHttpClientService.MoodleHttpClient.GetAsync(_moodleHttpClientService.MoodleUrl + query);
            var result = await response.Content.ReadAsStringAsync();
            var attemptRequest = JsonSerializer.Deserialize<AttemptRequest>(result, _jsonSerializerOptions);
            return attemptRequest.Attempts.Last();
        }

        public async Task<GradeForTask> GetAssignmentGradeAsync(int assignmentId, int userId)
        {
            var assignmentResult = await GetAssignmentResultAsync(assignmentId, userId);
            return new GradeForTask
            {
                UserId = assignmentResult.UserId,
                Grade = float.Parse(assignmentResult.grade.Replace('.', ',')),
                TaskType = nameof(TaskTypes.assign),
                TaskTypeId = assignmentResult.Id,
                TimeCreated = new DateTime(1970, 1, 1, 0, 0, 0, 0).
                    AddSeconds(assignmentResult.TimeCreated),
                TimeModified = new DateTime(1970, 1, 1, 0, 0, 0, 0).
                    AddSeconds(assignmentResult.TimeModified)
            };
        }
        
        public async Task<GradeForTask> GetQuizGradeAsync(int quizId, int userId)
        {
            var quizResult = await GetQuizResultAsync(quizId, userId);
            return new GradeForTask
            {
                UserId = quizResult.UserId,
                Grade = quizResult.SumGrades,
                TaskType = nameof(TaskTypes.quiz),
                TaskTypeId = quizResult.Id,
                TimeCreated = new DateTime(1970, 1, 1, 0, 0, 0, 0).
                    AddSeconds(quizResult.TimeStart),
                TimeModified = new DateTime(1970, 1, 1, 0, 0, 0, 0).
                    AddSeconds(quizResult.TimeFinish)
            };
        }
    }
}