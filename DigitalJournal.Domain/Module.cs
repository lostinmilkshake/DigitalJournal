namespace DigitalJournal.Domain
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public int CourseId { get; set; }
        public float MaxGrade { get; set; }
    }
}