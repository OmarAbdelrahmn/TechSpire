namespace TechSpire.Domain.Entities;
public class Posts
{
    public int Id { get; set; }
    public string URL { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int StageId { get; set; }
    public Stage Stage { get; set; } = default!;
}
