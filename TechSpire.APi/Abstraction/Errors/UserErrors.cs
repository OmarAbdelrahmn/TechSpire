﻿namespace SurvayBasket.Application.Abstraction.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials = new("User.InvalidCredentials", "Invalid Email/Password", StatusCodes.Status401Unauthorized);
    public static readonly Error EmailAlreadyExist = new("User.EmailAlreadyExist", "User with this email is already exists ", StatusCodes.Status409Conflict);
    public static readonly Error DuplicatedConfermation = new("User.EmailAlreadyConfirmed", "Email already confirmed", StatusCodes.Status400BadRequest);
    public static readonly Error EmailNotConfirmed = new("User.EmailNotConfirmed", "this email is not confirmed", StatusCodes.Status401Unauthorized);
    public static readonly Error UserNotFound = new("User.UserNotFound", "User not found", StatusCodes.Status401Unauthorized);
    public static readonly Error Disableuser = new("User.UserDisable", "User is disable , contact the administrator", StatusCodes.Status401Unauthorized);
    public static readonly Error userLockedout = new("User.LockedUser", "User is locked , contact the administrator", StatusCodes.Status401Unauthorized);
}
