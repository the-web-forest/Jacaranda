using System;
using Jacaranda.External.Repositories;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.UseCase.Interfaces.Services;

namespace Jacaranda.Configuration
{
    public static class Repositories
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();

            builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            builder.Services.AddScoped<ITreeRepository, TreeRepository>();
            builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
            builder.Services.AddScoped<IBiomeRepository, BiomeRepository>();

        }
    }
}

