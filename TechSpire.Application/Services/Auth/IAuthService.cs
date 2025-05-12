﻿using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Auth;

namespace TechSpire.Application.Services.Auth;

public interface IAuthService
{
    Task<Result<AuthResponse>> SingInAsync(AuthRequest request);
    Task<Result> RegisterAsync(RegisterRequest request);
    Task<Result> ConfirmEmailAsync(ConfigrationEmailRequest request);
    Task<Result> ResendEmailAsync(ResendEmailRequest request);
    Task<Result<AuthResponse>> GetRefreshTokenAsync(string Token, string RefreshToken);
    Task<Result> RevokeRefreshTokenAsync(string Token, string RefreshToken);
    Task<Result> ForgetPassordAsync(ForgetPasswordRequest request);
    Task<Result> ResetPasswordAsync(ResetPasswordRequest request);
}
