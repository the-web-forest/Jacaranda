using System;
namespace Jacaranda.UseCase.AdministratorLogin
{
    public class OutputUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class AdministratorLoginUseCaseOutput
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; } = "Bearer";
        public OutputUser User { get; set; }
    }
}

