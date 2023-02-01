namespace Jacaranda.Domain.Model
{
    public class PasswordReset : BaseModel
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ActivatedAt { get; set; }

        public User User { get; set; }
    }
}


