using System;
using Jacaranda.External.Repositories;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.Configuration
{
    public static class Repositories
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();

            builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
        }
    }
}

