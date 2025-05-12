﻿namespace TechSpire.Application.Contracts.Users;

public record UserResponse
(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsDisable
    );
