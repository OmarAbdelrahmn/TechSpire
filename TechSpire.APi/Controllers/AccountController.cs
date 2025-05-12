using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Contracts.Users;
using TechSpire.Application.Services.User;
using TechSpire.infra.Extensions;



namespace TechSpire.APi.Controllers;
[Route("me")]
[ApiController]
[Authorize]
public class AccountController(IUserService service) : ControllerBase
{
    private readonly IUserService service = service;

    [HttpGet("")]
    public async Task<IActionResult> ShowUserProfile()
    {
        var result = await service.GetUserProfile(User.GetUserId()!);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("info")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileRequest request)
    {
        var result = await service.UpdateUserProfile(User.GetUserId()!, request);

        return NoContent();
    }

    [HttpPut("change-passord")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var result = await service.ChangePassword(User.GetUserId()!, request);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
