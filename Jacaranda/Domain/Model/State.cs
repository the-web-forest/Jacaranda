using System;

namespace Jacaranda.Domain.Model
{
    public class State : BaseModel
    {
        public string Name { get; set; }
        public string Initials { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}

