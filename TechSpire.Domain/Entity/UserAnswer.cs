using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entity;
public class UserAnswer
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public AppUser User { get; set; } = default!;
    public Question Question { get; set; } = default!;
    public Answer Answer { get; set; } = default!;
}
