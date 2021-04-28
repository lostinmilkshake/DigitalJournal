using System.Collections.Generic;

namespace DigitalJournal.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public IEnumerable<int> ModulesId { get; set; }
        public IEnumerable<Module> Modules { get; set; }
    }
}