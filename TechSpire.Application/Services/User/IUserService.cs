using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Users;

namespace TechSpire.Application.Services.User;

public interface IUserService
{
    Task<Result<UserProfileResponse>> GetUserProfile(string id);
    Task<Result> UpdateUserProfile(string id, UpdateUserProfileRequest request);
    Task<Result> ChangePassword(string id, ChangePasswordRequest request);
}
