using BuberDinner.Application.Authentication;
using ErrorOr;

namespace BuberDinner.Application.Services;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult>  Login(string email, string password);
}