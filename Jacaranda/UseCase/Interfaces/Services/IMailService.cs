using System;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> SendWelcomeEmail(string Email, string Name, string Token, string Role);
        Task<bool> SendPasswordResetEmail(string Email, string Name, string Token, string Role);
        Task<bool> SendPlantSuccessEmail(string Email, string Name, Order Order, List<Tree> Trees);
        Task<bool> SendFirstPlantEmail(string Email, string Name);
    }
}

