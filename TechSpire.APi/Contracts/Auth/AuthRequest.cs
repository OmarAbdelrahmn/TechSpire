﻿namespace SurvayBasket.Application.Contracts.Auth;

public record AuthRequest
(
    string Email,
    string Password
    );
