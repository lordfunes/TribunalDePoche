namespace TribunalDePoche.Models
{
    public class Trial
    {
        public int Id { get; set; }
        public int CelebrityId { get; set; }
        public Celebrity Celebrity { get; set; }
        public string CaseName { get; set; }
        public string Description { get; set; }
        public DateTime TrialDate { get; set; }
        public string Status { get; set; } // pending, ongoing, closed
        public decimal? VerdictFine { get; set; }
        public int? VerdictSuspendedSentence { get; set; }
        public int? VerdictPrisonSentence { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
