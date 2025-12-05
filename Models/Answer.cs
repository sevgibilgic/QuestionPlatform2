namespace QuestionPlatform2.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
