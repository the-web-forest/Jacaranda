using System;
using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.External.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public List<City> FindCitiesByStateId(int StateId)
        {
            return _context.Where(x => x.StateId == StateId).OrderBy(x => x.Name).ToList();
        }
    }
}

