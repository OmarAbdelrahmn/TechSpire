using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Contracts.Fav;
using TechSpire.Application.Services;
using TechSpire.infra.Extensions;

namespace TechSpire.APi.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]
public class FavController(IFavService service) : ControllerBase
{
    private readonly IFavService service = service;

    [HttpGet("")]
    public async Task<IActionResult> Show()
    {
        var UserId = User.GetUserId()!;

        var result = await service.Show(UserId);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPut("")]
    public async Task<IActionResult> Clear()
    {
        var UserId = User.GetUserId()!;
        var result = await service.Clear(UserId);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("")]
    public async Task<IActionResult> addItem(FavRequest request)
    {
        var UserId = User.GetUserId()!;
        var result = await service.AddItem(UserId,request);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpDelete("")]
    public async Task<IActionResult> Delete(FavRequest request)
    {
        var UserId = User.GetUserId()!;
        var result = await service.DeItem(UserId,request);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }
}
