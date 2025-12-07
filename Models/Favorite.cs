namespace QuestionPlatform2.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int QuestionId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Question Question { get; set; }
    }
}
