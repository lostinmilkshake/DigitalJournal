using System;

namespace DigitalJournal.Moodle.Domain
{
    public class Grades
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AttemptNumber { get; set; }
        public long TimeCreated { get; set; }
        public long TimeModified { get; set; }
        public int Grader { get; set; }

        public string grade { get; set; }
    }
}