namespace DigitalJournal.Moodle.Domain
{
    public class Course
    {
        
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public int EnrolledUserCount { get; set; }
        public string IdNumber { get; set; }
        public int Visible { get; set; }
        public string Summary { get; set; }
        public int SummaryFormat { get; set; }
        public string Format { get; set; }
        public bool ShowGrades { get; set; }
        public string Lang { get; set; }
        public bool EnableCompletion { get; set; }
    }
}