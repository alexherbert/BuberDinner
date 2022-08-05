using BuberDinner.Application.Authentication;
using ErrorOr;

namespace BuberDinner.Application.Services;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}