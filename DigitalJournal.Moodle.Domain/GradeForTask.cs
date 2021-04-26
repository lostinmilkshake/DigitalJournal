using System;

namespace DigitalJournal.Moodle.Domain
{
    public class GradeForTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
            
        public int TaskTypeId { get; set; }
        public string TaskType { get; set; }
        public float Grade { get; set; }
    }
}