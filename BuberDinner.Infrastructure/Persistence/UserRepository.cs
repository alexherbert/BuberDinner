using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}