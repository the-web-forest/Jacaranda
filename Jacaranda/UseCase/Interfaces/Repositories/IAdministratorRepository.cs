using System;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IAdministratorRepository : IBaseRepository<Administrator>
    {
        Task<Administrator> GetByEmail(string Email);
    }
}

