using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entity;
public class Stage
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Lesson> Lessons { get; set; } = [];
    public List<Post> Posts{ get; set; } = [];
    public List<Article> Articles{ get; set; } = [];
    public List<Book> Books{ get; set; } = [];

}
