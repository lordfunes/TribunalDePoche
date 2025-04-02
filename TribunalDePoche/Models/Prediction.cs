namespace TribunalDePoche.Models
{
    public class Prediction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TrialId { get; set; }
        public Trial? Trial { get; set; }
        public decimal PredictedFine { get; set; }
        public int PredictedSuspendedSentence { get; set; }
        public int PredictedPrisonSentence { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
