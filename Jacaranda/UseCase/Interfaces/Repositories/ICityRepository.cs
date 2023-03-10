using System;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface ICityRepository : IBaseRepository<City>
    {
        List<City> FindCitiesByStateId(int StateId);
    }
}

