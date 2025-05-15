using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Stage;
using TechSpire.Application.Services;
using TechSpire.Domain.Entities;
using TechSpire.infra.Dbcontext;

namespace TechSpire.infra.Services;
public class DataService(AppDbcontext dbcontext) : IDataService
{
    private readonly AppDbcontext dbcontext = dbcontext;

    public async Task<Result<IEnumerable<ArticleResponse>>> GetAllArticleAsync()
    {
        var Articles = await dbcontext.Articles
            .ProjectToType<ArticleResponse>()
            .AsNoTracking()
            .ToListAsync();

        if (Articles is null || Articles.Count == 0)
            return Result.Failure<IEnumerable<ArticleResponse>>(new Error("No.Article", "No articel found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<ArticleResponse>>(Articles);
    }

    public async Task<Result<IEnumerable<BookResponse>>> GetAllBookAsync()
    {
        var Books = await dbcontext.Books
            .ProjectToType<BookResponse>()
            .AsNoTracking()
            .ToListAsync();

        if (Books is null || Books.Count == 0)
            return Result.Failure<IEnumerable<BookResponse>>(new Error("No.Books", "No Books found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<BookResponse>>(Books);
    }

    public async Task<Result<IEnumerable<LessonResponse>>> GetAllLessonAsync()
    {
        var lessons = await dbcontext.Lessons
            .ProjectToType<LessonResponse>()
            .AsNoTracking()
            .ToListAsync();

        if (lessons is null || lessons.Count == 0)
            return Result.Failure<IEnumerable<LessonResponse>>(new Error("No.lessons", "No lessons found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<LessonResponse>>(lessons);
    }

    public async Task<Result<IEnumerable<PostResponse>>> GetAllPostAsync()
    {
        var Posts = await dbcontext.Posts
            .ProjectToType<PostResponse>()
            .AsNoTracking()
            .ToListAsync();

        if (Posts is null || Posts.Count == 0)
            return Result.Failure<IEnumerable<PostResponse>>(new Error("No.Posts", "No Posts found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<PostResponse>>(Posts);
    }

    public async Task<Result<ArticleResponse>> GetArticleByIdAsync(int ArticleId)
    {
        var article = await dbcontext.Articles.FindAsync(ArticleId);

        if(article is null)
            return Result.Failure<ArticleResponse>(new Error("No.Article", "No articel found", StatusCodes.Status404NotFound));

        return Result.Success(article.Adapt<ArticleResponse>());
    }

    public async Task<Result<IEnumerable<ArticleResponse>>> GetArticleByNameAsync(string ArticleName)
    {
        var article = await dbcontext.Articles
            .Where(c=>c.Title.Contains(ArticleName))
            .ProjectToType<ArticleResponse>()
            .ToListAsync();

        if (article is null || article.Count == 0)
            return Result.Failure<IEnumerable<ArticleResponse>>(new Error("No.Article", "No articel found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<ArticleResponse>>(article);
    }

    public async Task<Result<BookResponse>> GetBookByIdAsync(int BookId)
    {
        var Book = await dbcontext.Books.FindAsync(BookId);

        if (Book is null)
            return Result.Failure<BookResponse>(new Error("No.Book", "No Book found", StatusCodes.Status404NotFound));

        return Result.Success(Book.Adapt<BookResponse>());
    }

    public async Task<Result<IEnumerable<BookResponse>>> GetBookByNameAsync(string BookName)
    {
        var Books = await dbcontext.Books
            .Where(c => c.Title.Contains(BookName))
            .ProjectToType<BookResponse>()
            .ToListAsync();

        if (Books is null || Books.Count == 0)
            return Result.Failure<IEnumerable<BookResponse>>(new Error("No.Books", "No Books found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<BookResponse>>(Books);
    }

    public async Task<Result<LessonResponse>> GetLessonByIdAsync(int LessonId)
    {
        var Lesson = await dbcontext.Lessons.FindAsync(LessonId);

        if (Lesson is null)
            return Result.Failure<LessonResponse>(new Error("No.Lesson", "No Lesson found", StatusCodes.Status404NotFound));

        return Result.Success(Lesson.Adapt<LessonResponse>());
    }

    public async Task<Result<IEnumerable<LessonResponse>>> GetLessonByNameAsync(string LessonName)
    {
        var Lesson = await dbcontext.Lessons
            .Where(c => c.Title.Contains(LessonName))
            .ProjectToType<LessonResponse>()
            .ToListAsync();

        if (Lesson is null || Lesson.Count == 0)
            return Result.Failure<IEnumerable<LessonResponse>>(new Error("No.lessons", "No lessons found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<LessonResponse>>(Lesson);
    }

    public async Task<Result<IEnumerable<PostResponse>>> GetPostAsync(string PostName)
    {
        var Post = await dbcontext.Posts
            .Where(c => c.Title.Contains(PostName))
            .ProjectToType<PostResponse>()
            .ToListAsync();

        if (Post is null || Post.Count == 0)
            return Result.Failure<IEnumerable<PostResponse>>(new Error("No.Posts", "No Posts found", StatusCodes.Status404NotFound));

        return Result.Success<IEnumerable<PostResponse>>(Post);
    }

    public async Task<Result<PostResponse>> GetPostByIdAsync(int PostId)
    {
        var Post = await dbcontext.Posts.FindAsync(PostId);

        if (Post is null)
            return Result.Failure<PostResponse>(new Error("No.Post", "No Post found", StatusCodes.Status404NotFound));

        return Result.Success(Post.Adapt<PostResponse>());
    }
}
