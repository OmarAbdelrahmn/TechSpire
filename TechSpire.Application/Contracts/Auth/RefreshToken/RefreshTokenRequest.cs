﻿namespace TechSpire.Application.Contracts.Auth.RefreshToken;

public record RefreshTokenRequest
(
    string Token,
    string RefreshToken
);
