using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entity;
public class Posts
{
    public int Id { get; set; }
    public string URL { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int StageId { get; set; }
    public Stage Stage { get; set; } = default!;
}
