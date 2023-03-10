using System;
using Jacaranda.Context;
using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.External.Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public List<State> FindAll()
        {
            return _context.Where(x => x.Name != null).OrderBy(x => x.Name).ToList();
        }

        public State FindStateByInitial(string StateInitial)
        {
            return _context.Where(x => x.Initials == StateInitial).FirstOrDefault();
        }
    }
}

