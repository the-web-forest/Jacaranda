using System;

namespace Jacaranda.Domain.Model
{
    public class City : BaseModel
    {
        public string Name { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

