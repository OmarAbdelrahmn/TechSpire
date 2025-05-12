﻿namespace TechSpire.Domain.Entities;
public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public Question Question { get; set; } = default!;
    //public UserAnswer UserAnswers { get; set; } =default!;
}
