using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password
    ): IRequest<ErrorOr<AuthenticationResult>>;
}