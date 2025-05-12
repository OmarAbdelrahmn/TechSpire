namespace TechSpire.Domain.Entities;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string BookUrl { get; set; } = string.Empty;
    public int StageId { get; set; }
    public Stage Stage { get; set; } = default!;
}
