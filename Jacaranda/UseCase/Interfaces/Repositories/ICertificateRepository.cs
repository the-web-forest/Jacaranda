using System;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface ICertificateRepository : IBaseRepository<Models.Certificate>
    {
        Task<Models.Certificate> GetByCertificateId(string CertificateId);
    }
}

