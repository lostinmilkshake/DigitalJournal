using System.Collections;
using System.Collections.Generic;

namespace DigitalJournal.Moodle.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Module> Modules { get; set; }
    }
}