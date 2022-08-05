using BuberDinner.Application.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Commands.Register;

public record RegisterCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;