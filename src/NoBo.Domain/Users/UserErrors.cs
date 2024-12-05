using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Users;

public class UserErrors
{
    public static Error NotFound = new(
        "User.NotFound",
        "The user with th specified identifier was not found.");

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "The provided credentials were invalid.");
}