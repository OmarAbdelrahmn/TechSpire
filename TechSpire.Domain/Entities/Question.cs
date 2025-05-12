namespace TechSpire.Domain.Entities;
public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = default!;
    public List<Answer> Answers { get; set; } = [];
    //public UserAnswer UserAnswer { get; set; } = default!;
}
