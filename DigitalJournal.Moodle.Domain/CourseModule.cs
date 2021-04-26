using System.Text.Json.Serialization;

namespace DigitalJournal.Moodle.Domain
{
    public class CourseModule
    {
        [JsonPropertyName("cm")]
        public Module Module { get; set; }
    }
}