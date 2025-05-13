namespace TechSpire.Domain.Entities;
public class Stage
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Lesson> Lessons { get; set; } = [];
    public List<Post> Posts { get; set; } = [];
    public List<Article> Articles { get; set; } = [];
    public List<Book> Books { get; set; } = [];
    public List<Quiz> Quizzes { get; set; } = [];

}
