using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DigitalJournal.Moodle.Domain
{
    public class Root
    {
        [JsonPropertyName("assignments")]
        public IEnumerable<Assignment> Assignments { get; set; }
    }
}