﻿namespace TechSpire.APi.Contracts.Auth;

public record RegisterRequest
(
    string Email,
    string Password,
    string FirstName,
    string LastName
    );
