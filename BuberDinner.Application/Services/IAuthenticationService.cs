﻿using BuberDinner.Application.Authentication;
using FluentResults;

namespace BuberDinner.Application.Services;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}