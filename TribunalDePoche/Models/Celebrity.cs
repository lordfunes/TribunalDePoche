namespace TribunalDePoche.Models
{
    public class Celebrity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public List<Trial> Trials { get; set; } = new List<Trial>();
    }
}
