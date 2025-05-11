namespace SurvayBasket.Application.Contracts.Auth.RefreshToken;

public record RefreshTokenRequest
(
    string Token,
    string RefreshToken
);
