using System;

namespace Jacaranda.Domain.Model
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int CityId { get; set; }
        public string Password { get; set; }
        public bool EmailVerified { get; set; }
        public string Origin { get; set; }
        public bool AllowNewsletter { get; set; }

        public City City { get; set; }
        public ICollection<Plant> Plants { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PasswordReset> PasswordResets { get; set; }

    }
}

