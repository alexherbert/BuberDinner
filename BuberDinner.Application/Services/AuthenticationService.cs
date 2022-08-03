using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain;

namespace BuberDinner.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with email already exists");
        }
        
        // Create user
        var user = new User( Guid.NewGuid(), firstName, lastName, email, password);
        
        // Create JWT
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User with email doesn't exist");

        if (user.Password != password)
            throw new Exception("Invalid Password");

        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new(
            user,
            token);
    }
}