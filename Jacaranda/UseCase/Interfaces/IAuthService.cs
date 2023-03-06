using System;
using System.Data;
using Jacaranda.Domain;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Models.Administrator User);
        string GenerateToken(Models.User User);
    }
}

