using System;

namespace DigitalJournal.Domain
{
    public class TaskResult
    {
        public string TaskType { get; set; }
        public int TaskTypeId { get; set; }
        public float Grade { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}