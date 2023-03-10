using System;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Repositories
{
    public interface IStateRepository : IBaseRepository<State>
    {
        List<State> FindAll();
        State FindStateByInitial(string StateInitial);
    }
}

