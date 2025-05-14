using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Contracts.Fav;
using TechSpire.Application.Services;

namespace TechSpire.APi.Controllers;
[Route("[controller]")]
[ApiController]
public class FavController(IFavService service) : ControllerBase
{
    private readonly IFavService service = service;

    [HttpGet("")]
    public async Task<IActionResult> Show(string UserId)
    {
        var result = await service.Show(UserId);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPut("")]
    public async Task<IActionResult> Clear(string UserId)
    {
        var result = await service.Clear(UserId);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("")]
    public async Task<IActionResult> addItem(FavRequest request)
    {
        var result = await service.AddItem(request);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpDelete("")]
    public async Task<IActionResult> Delete(FavRequest request)
    {
        var result = await service.DeItem(request);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }
}
