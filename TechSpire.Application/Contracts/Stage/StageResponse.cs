
using TechSpire.Domain.Entities;

namespace TechSpire.Application.Contracts.Stage;
public record StageResponse(
    int Id,
    string Name,
    List<Lesson> Lessons,
    List<Post> Posts,
    List<Article> Articles,
    List<Book> Books
    );