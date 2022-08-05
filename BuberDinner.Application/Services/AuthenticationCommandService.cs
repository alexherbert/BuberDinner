using BuberDinner.Application.Authentication;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using User = BuberDinner.Domain.User;

namespace BuberDinner.Application.Services;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if user exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Domain.Common.Errors.User.DuplicateEmailError;
        }
        
        // Create user
        var user = new User( Guid.NewGuid(), firstName, lastName, email, password);
        _userRepository.Add(user);
        
        // Create JWT
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }
}