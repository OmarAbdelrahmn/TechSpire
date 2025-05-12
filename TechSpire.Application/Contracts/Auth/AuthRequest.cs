namespace TechSpire.Application.Contracts.Auth;

public record AuthRequest
(
    string Email,
    string Password
    );
