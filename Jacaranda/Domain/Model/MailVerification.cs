using System;
namespace Jacaranda.Domain.Model
{
    public class MailVerification : BaseModel
    {
        public string Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ActivatedAt { get; set; }
    }
}

