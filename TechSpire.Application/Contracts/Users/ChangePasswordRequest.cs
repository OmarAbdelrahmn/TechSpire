namespace TechSpire.Application.Contracts.Users;

public record ChangePasswordRequest
(
    string CurrentPassword,
    string NewPassord
    );
