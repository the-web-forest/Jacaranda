using System;
namespace Jacaranda.UseCase.User.PasswordChange
{
    public class UserPasswordChangeUseCaseInput
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}

