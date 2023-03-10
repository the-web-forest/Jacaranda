using System;
using Ipe.Domain.Errors;

namespace Jacaranda.UseCase.Configuration.GetPublicConfigurationUseCase
{
    public class GetPublicConfigurationUseCase : IUseCase<GetPublicConfigurationUseCaseInput, GetPublicConfigurationUseCaseOutput>
    {
        private IConfiguration _configuration { get; }

        public GetPublicConfigurationUseCase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<GetPublicConfigurationUseCaseOutput> Run(GetPublicConfigurationUseCaseInput Input)
        {
            string? configuration = _configuration["Portal:Configuration"];

            if (string.IsNullOrEmpty(configuration))
                throw new ConfigurationNotFoundException();

            return Task.FromResult(new GetPublicConfigurationUseCaseOutput
            {
                Config = configuration
            });
        }
    }
}

