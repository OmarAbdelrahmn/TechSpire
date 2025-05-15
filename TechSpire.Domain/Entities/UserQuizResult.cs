using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entities;
public class UserQuizResult
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int QuizId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public double CorrectPercentage { get; set; }
    public double WrongPercentage { get; set; }

    public ApplicataionUser User { get; set; } = default!;
    public Quiz Quiz { get; set; } = default!;
    
}
