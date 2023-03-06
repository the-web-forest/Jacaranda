using System;
namespace Jacaranda.Domain.Model
{
    public class MailVerification : BaseModel
    {
        public string Token { get; set; }
        public DateTime? ActivatedAt { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}

