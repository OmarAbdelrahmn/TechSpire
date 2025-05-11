using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entity;
public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = default!;
    public List<Answer> Answers { get; set; } = [];
}
