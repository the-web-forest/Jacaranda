using System;
using Jacaranda.External.Repositories;
using Jacaranda.Tests.Context;
using Jacaranda.UseCase;
using Jacaranda.UseCase.Certificate.GetCertificateByIdUseCase;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Jacaranda.Tests
{
    public class Fixture : TestBedFixture
    {
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddTransient<DatabaseContext>();
            services.AddTransient<IAdministratorRepository, AdministratorRepository>();
            services.AddTransient<ICertificateRepository, CertificateRepository>();
            services.AddTransient<IUseCase<GetCertificateByIdUseCaseInput, GetCertificateByIdUseCaseOutput>, GetCertificateByIdUseCase>();
        }

        protected override ValueTask DisposeAsyncCore()
            => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "appsettings.json", IsOptional = false };
        }
    }
}

