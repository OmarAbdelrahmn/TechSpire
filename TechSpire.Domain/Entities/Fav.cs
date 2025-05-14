using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entities;
public class Fav
{
    public int ItemId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public ApplicataionUser User { get; set; } = default!;
}
