using System;
namespace Jacaranda.UseCase.Interfaces.Repositories
{	
	public interface IBaseRepository<T>
	{
		Task<T> FindById(int Id);
		void Update(T Model);
		void SoftDelete(T Model);
		Task Create(T Model);
    }
}

