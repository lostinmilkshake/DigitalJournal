namespace DigitalJournal.Moodle.Domain
{
    public class Attempt
    {
        public int Id { get; set; }
        public int Quiz { get; set; }
        public int UserId { get; set; }
        public float SumGrades { get; set; }
        public long TimeStart { get; set; }
        public long TimeFinish { get; set; }
    }
}
