using BuberDinner.Application.Authentication;
using BuberDinner.Application.Services;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;
    private readonly IMediator _mediator;

    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService, IMediator mediator)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
        _mediator = mediator;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result =
            _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return result.Match(
            authResult => Ok(new AuthenticationResponse(
                result.Value.User.Id,
                result.Value.User.FirstName,
                result.Value.User.LastName,
                result.Value.User.Email,
                result.Value.Token)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationQueryService.Login(request.Email, request.Password);
        
        return result.Match(
            authResult => Ok(MapAuthResult(authResult)),
            Problem);

    }
}