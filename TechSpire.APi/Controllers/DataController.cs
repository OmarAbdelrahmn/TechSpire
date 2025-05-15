using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Services;

namespace TechSpire.APi.Controllers;
[Route("[controller]")]
[ApiController]
public class DataController(IDataService service) : ControllerBase
{
    private readonly IDataService service = service;

    [HttpGet("book")]
    public async Task<IActionResult> GetAllBooks()
    {
        var result = await service.GetAllBookAsync();

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
    
    [HttpGet("book/{Id:int}")]
    public async Task<IActionResult> GetByIdBooks(int Id)
    {
        var result = await service.GetBookByIdAsync(Id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("book/{Name:alpha}")]
    public async Task<IActionResult> GetByNameBooks(string Name)
    {
        var result = await service.GetBookByNameAsync(Name);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("article")]
    public async Task<IActionResult> GetAllarticle()
    {
        var result = await service.GetAllArticleAsync();

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("article/{Id:int}")]
    public async Task<IActionResult> GetByIdarticle(int Id)
    {
        var result = await service.GetArticleByIdAsync(Id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("article/{Name:alpha}")]
    public async Task<IActionResult> GetByArticleBooks(string Name)
    {
        var result = await service.GetArticleByNameAsync(Name);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("post")]
    public async Task<IActionResult> GetAllPost()
    {
        var result = await service.GetAllPostAsync();

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("post/{Id:int}")]
    public async Task<IActionResult> GetByIdPost(int Id)
    {
        var result = await service.GetPostByIdAsync(Id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("post/{Name:alpha}")]
    public async Task<IActionResult> GetByNamepost(string Name)
    {
        var result = await service.GetPostAsync(Name);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("lesson")]
    public async Task<IActionResult> GetAllLessons()
    {
        var result = await service.GetAllLessonAsync();

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("lesson/{Id:int}")]
    public async Task<IActionResult> GetByIdLesson(int Id)
    {
        var result = await service.GetLessonByIdAsync(Id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("lesson/{Name:alpha}")]
    public async Task<IActionResult> GetByNameLesson(string Name)
    {
        var result = await service.GetLessonByNameAsync(Name);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
