using BuberDinner.Domain;

namespace BuberDinner.Application.Authentication;

public record AuthenticationResult(
    User User,
    string Token);