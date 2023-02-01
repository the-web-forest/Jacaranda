using System;
using Jacaranda.Context;
using Jacaranda.Helper;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.External.Repositories
{
	public class BaseRepository<T>: IBaseRepository<T> where T: BaseModel 
	{
		protected readonly DatabaseContext _databaseContext;
		protected readonly DbSet<T> _context;

		public BaseRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
			_context = _databaseContext.Set<T>();
		}

		public async Task<T> FindById(int Id)
		{
			return await _context.Where(x => x.Id == Id).FirstOrDefaultAsync();
		}

		public void Update(T Model)
		{
			Model.UpdatedAt = DateHelper.BrazilDateTimeNow();
			_context.Update(Model);
			_databaseContext.SaveChanges();
        }

        public void SoftDelete(T Model)
        {
            Model.UpdatedAt = DateHelper.BrazilDateTimeNow();
			Model.Deleted = true;
            _context.Update(Model);
            _databaseContext.SaveChanges();
        }

        public async Task Create(T Model)
        {
            Model.UpdatedAt = DateHelper.BrazilDateTimeNow();
            Model.CreatedAt = DateHelper.BrazilDateTimeNow();
            await _context.AddAsync(Model);
            _databaseContext.SaveChanges();
        }
    }
}

