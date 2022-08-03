using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user exists
        
        // Create user
        
        // Create JWT
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }
}