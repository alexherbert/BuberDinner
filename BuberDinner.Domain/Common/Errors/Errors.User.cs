using System.Security.Cryptography;
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static class User
{
    public static Error DuplicateEmailError = Error.Conflict(code: "User.Error.DuplicateEmailError", description: "User.Error.DuplicateEmailError");
    public static Error UserUnknown = Error.Conflict(code: "User.Error.UserUnknown", description: "User.Error.UserUnknown");
    public static Error InvalidPassword = Error.Conflict(code: "User.Error.InvalidPassword", description: "User.Error.InvalidPassword");
}