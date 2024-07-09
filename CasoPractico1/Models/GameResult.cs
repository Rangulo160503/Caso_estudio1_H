namespace CasoPractico1.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int Score { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
    }
}
