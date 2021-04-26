using System.Collections.Generic;

namespace DigitalJournal.Moodle.Domain
{
    public class AttemptRequest
    {
        public IEnumerable<Attempt> Attempts { get; set; }
    }
}