using System;
using Jacaranda.Domain.Exceptions.Certificate;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.Certificate.GetCertificateByIdUseCase
{
    public class GetCertificateByIdUseCase : IUseCase<GetCertificateByIdUseCaseInput, GetCertificateByIdUseCaseOutput>
    {

        private readonly ICertificateRepository _certificateRepository;

        public GetCertificateByIdUseCase(
            ICertificateRepository certificateRepository
            )
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<GetCertificateByIdUseCaseOutput> Run(GetCertificateByIdUseCaseInput Input)
        {
            var Data = await _certificateRepository.GetByCertificateId(Input.CertificateId);

            if (Data == null)
            {
                throw new InvalidCertificateException();
            }

            return new GetCertificateByIdUseCaseOutput
            {
                CertificateUrl = Data.File,
                Name = Data.Name,
                Id = Data.Id.ToString(),
                CreatedAt = Data.CreatedAt,
                UpdatedAt = Data.UpdatedAt
            };
        }
    }
}

