using QuestionPlatform2.Models;

public class Answer
{
    public int Id { get; set; }
    public string AnswerContent { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; internal set; }
}
