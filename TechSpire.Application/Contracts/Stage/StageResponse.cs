
using TechSpire.Domain.Entities;

namespace TechSpire.Application.Contracts.Stage;
public record StageResponse(
    int Id,
    string Name,
    List<LessonResponse> Lessons,
    List<PostResponse> Posts,
    List<ArticleResponse> Articles,
    List<BookResponse> Books
    );