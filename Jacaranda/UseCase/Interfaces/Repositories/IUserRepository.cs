using System;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<Models.User>
    {
        Task<Models.User> GetByEmail(string Email);
        Task<Models.User> GetById(int UserId);
        Task<List<Models.User>> ListUsersPerPage(int Page, int ItensPerPage);
        Task<long> CountUsers();
    }
}

