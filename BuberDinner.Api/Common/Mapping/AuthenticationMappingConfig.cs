using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, AuthenticationResponse>();
            config.NewConfig<LoginRequest, AuthenticationResponse>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()

            .Map(dest => dest, src => src.User);
        }
    }
}