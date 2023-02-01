using System;
namespace Jacaranda.UseCase.Certificate.GetCertificateByIdUseCase
{
    public class GetCertificateByIdUseCaseOutput
    {
        public string CertificateUrl { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

