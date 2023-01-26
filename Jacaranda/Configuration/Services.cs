using System;
using Jacaranda.External.Services;
using Jacaranda.UseCase.Interfaces;

namespace Jacaranda.Configuration
{
    public static class Services
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IAuthService, JWTService>();
        }
    }
}

