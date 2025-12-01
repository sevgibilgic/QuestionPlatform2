namespace QuestionPlatform2.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
