using System.Text.Json.Serialization;

namespace DigitalJournal.Moodle.Domain
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Instance { get; set; }
        public string ModName { get; set; }
        public float Grade { get; set; }
        public int Course { get; set; }
        public int module { get; set; }
    }
}