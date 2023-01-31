using System;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
	public interface IUserRepository: IBaseRepository<Models.User>
	{
        Task<Models.User> GetByEmail(string Email);
    }
}

