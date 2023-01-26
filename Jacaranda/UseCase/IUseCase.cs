using System;
namespace Jacaranda.UseCase
{
    public interface IUseCase<Input, Output>
    {
        Task<Output> Run(Input Input);
    }
}

