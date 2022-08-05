using BuberDinner.Domain;

namespace BuberDinner.Application.Common;

public record AuthenticationResult(
    User User,
    string Token);