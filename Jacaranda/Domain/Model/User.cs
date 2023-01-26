using System;
using Jacaranda.Model;

namespace Jacaranda.Domain.Model
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool EmailVerified { get; set; }
        public string Origin { get; set; }
        public bool AllowNewsletter { get; set; }
    }
}

