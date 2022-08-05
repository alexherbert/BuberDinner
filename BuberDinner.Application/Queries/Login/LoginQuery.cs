using BuberDinner.Application.Common;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Queries.Login;

public record LoginQuery(
    string Email, 
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;