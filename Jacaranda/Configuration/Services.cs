using System;
using Jacaranda.External.Services;
using Jacaranda.UseCase.Interfaces;
using Jacaranda.UseCase.Interfaces.Services;
using SendGrid;

namespace Jacaranda.Configuration
{
    public static class Services
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IAuthService, JWTService>();

            builder.Services.AddSingleton(x =>
                new SendGridClient(builder.Configuration["Email:ApiKey"])
            );

            builder.Services.AddScoped<IStorageService, StorageService>();
            builder.Services.AddScoped<IEmailService, SendGridService>();
        }
    }
}

