using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Stage;

namespace TechSpire.Application.Services;
public interface IDataService
{
    //Lesson-Service
    Task<Result<IEnumerable<LessonResponse>>> GetAllLessonAsync();
    Task<Result<LessonResponse>> GetLessonByIdAsync(int LessonId);
    Task<Result<IEnumerable<LessonResponse>>> GetLessonByNameAsync(string LessonName);
    //Post-Service
    Task<Result<IEnumerable<PostResponse>>> GetAllPostAsync();
    Task<Result<PostResponse>> GetPostByIdAsync(int PostId);
    Task<Result<IEnumerable<PostResponse>>> GetPostAsync(string PostName);
    //Article-Service
    Task<Result<IEnumerable<ArticleResponse>>> GetAllArticleAsync();
    Task<Result<ArticleResponse>> GetArticleByIdAsync(int ArticleId);
    Task<Result<IEnumerable<ArticleResponse>>> GetArticleByNameAsync(string ArticleName);
    //Book-Service
    Task<Result<IEnumerable<BookResponse>>> GetAllBookAsync();
    Task<Result<BookResponse>> GetBookByIdAsync(int BookId);
    Task<Result<IEnumerable<BookResponse>>> GetBookByNameAsync(string BookName);
}
