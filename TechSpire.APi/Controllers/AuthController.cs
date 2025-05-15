﻿using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Contracts.Auth;
using TechSpire.Application.Contracts.Auth.RefreshToken;
using TechSpire.Application.Services.Auth;

namespace TechSpire.APi.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> login([FromBody] AuthRequest request)
    {
        var response = await service.SingInAsync(request);

        return response.IsSuccess ?
            Ok(response.Value) :
            response.ToProblem();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await service.RegisterAsync(request);

        return response.IsSuccess ?
            Ok() :
            response.ToProblem();
    }

    [HttpGet("emailconfigration")]
    public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userid, string code)
    {
        var request = new ConfigrationEmailRequest
        (
           userid,
           code
        );

        var response = await service.ConfirmEmailAsync(request);

        return response.IsSuccess ?
            Ok() :
            response.ToProblem();
    }


    [HttpPost("resend-configration-email")]
    public async Task<IActionResult> ResendConfirmEmailAsync([FromBody] ResendEmailRequest request)
    {
        var response = await service.ResendEmailAsync(request);

        return response.IsSuccess ?
            Ok() :
            response.ToProblem();
    }



    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var response = await service.GetRefreshTokenAsync(request.Token, request.RefreshToken);

        return response.IsSuccess ?
            Ok(response.Value) :
            response.ToProblem();
    }



    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request)
    {
        var response = await service.RevokeRefreshTokenAsync(request.Token, request.RefreshToken);

        return response.IsSuccess ?
            Ok() :
            response.ToProblem();
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
    {
        var response = await service.ForgetPassordAsync(request);

        return response.IsSuccess ?
                Ok() :
                response.ToProblem();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var response = await service.ResetPasswordAsync(request);

        return response.IsSuccess ?
                Ok() :
                response.ToProblem();
    }
}
