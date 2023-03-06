using System;
using Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.User.GetUserInfo
{
    public class GetUserInfoUseCaseOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Photo { get; set; }
        public City? City { get; set; }
        public bool AllowNewsletter { get; set; }
    }
}

