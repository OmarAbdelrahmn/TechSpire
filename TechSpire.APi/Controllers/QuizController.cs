using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Contracts.Stage;
using TechSpire.Application.Services;

namespace TechSpire.APi.Controllers;
[Route("[controller]")]
[ApiController]
public class QuizController(IQuizService service) : ControllerBase
{
    private readonly IQuizService service = service;

    [HttpGet("stage/{Id}")]
    public async Task<IActionResult> GetAllQuizsForStage(int Id)
    {
        var result = await service.GetAllQuizsForStage(Id);
        
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetQuiz(int Id)
    {
        var result = await service.GetQuizWithId(Id);
        
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
    [HttpPost("submit/{userId}")]
    public async Task<IActionResult> SubmitUserAnswers([FromBody] List<UserAnswerRequest> answers , string userId)
    {
        var result = await service.SubmitUserAnswersAsync(userId, answers);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
