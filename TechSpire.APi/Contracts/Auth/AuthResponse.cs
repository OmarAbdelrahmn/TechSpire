﻿namespace SurvayBasket.Application.Contracts.Auth;

public record AuthResponse
(
    string Id,
    string email,
    string FirstName,
    string LastName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime RefreshExpiresIn
    );
