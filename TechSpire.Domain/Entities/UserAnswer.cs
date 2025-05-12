namespace TechSpire.Domain.Entities;
public class UserAnswer
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public ApplicataionUser User { get; set; } = default!;
    public Question Question { get; set; } = default!;
    public Answer Answer { get; set; } = default!;
}
