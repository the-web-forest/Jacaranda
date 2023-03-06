using System;
namespace Jacaranda.UseCase.User.Login
{
    public class OutputUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
    }

    public class UserLoginUseCaseOutput
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public OutputUser User { get; set; }
    }
}

