using System;
using Jacaranda.UseCase;
using Jacaranda.UseCase.AdministratorLogin;
using Jacaranda.UseCase.Certificate.GetCertificateByIdUseCase;

namespace Jacaranda.Configuration
{
    public static class UseCases
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUseCase<AdministratorLoginUseCaseInput, AdministratorLoginUseCaseOutput>, AdministratorLoginUseCase>();


            builder.Services.AddScoped<IUseCase<GetCertificateByIdUseCaseInput, GetCertificateByIdUseCaseOutput>, GetCertificateByIdUseCase>();
        }
    }
}

