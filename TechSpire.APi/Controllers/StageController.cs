using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Services;
using TechSpire.infra.Extensions;

namespace TechSpire.APi.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]
public class StageController(IStageService service) : ControllerBase
{
    private readonly IStageService service = service;

    [HttpGet("")]
    public async Task<IActionResult> GetAllStagesWithData()
    {
        var result = await service.GetAllStagesWithData();

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProblem();
    }
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetStageWithData(int Id)
    {
        var result = await service.GetStageWithData(Id);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProblem();
    }
    
    [HttpPost("{Lessonid}")]
    public async Task<IActionResult> CompleteLesson( int Lessonid)
    {
        var UserId = User.GetUserId();

        var result = await service.CompleteLesson(UserId , Lessonid);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProblem();
    }
}
