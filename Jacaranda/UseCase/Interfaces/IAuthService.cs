using System;
using System.Data;
using Jacaranda.Domain;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Administrator User, Roles Role);
    }
}

