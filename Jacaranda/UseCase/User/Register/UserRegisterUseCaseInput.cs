using System;
namespace Jacaranda.UseCase.User.Register
{
    public class UserRegisterUseCaseInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AllowNewsletter { get; set; } = true;
    }
}

