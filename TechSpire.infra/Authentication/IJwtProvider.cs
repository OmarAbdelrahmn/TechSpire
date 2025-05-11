namespace SurvayBasket.Infrastructure.Authentication;

public interface IJwtProvider
{
    (string Token, int Expiry) GenerateToken(ApplicataionUser user);

    string? ValidateToken(string token);
}
