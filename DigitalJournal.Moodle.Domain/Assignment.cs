using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DigitalJournal.Moodle.Domain
{
    public class Assignment 
    {
        public int AssignmentId { get; set; }
        [JsonPropertyName("grades")]
        public IEnumerable<Grades> Grades { get; set; }
    }
}