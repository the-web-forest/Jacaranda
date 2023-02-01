namespace Jacaranda.Domain.Model
{
    public class Order : BaseModel
    {
        public string Status { get; set; }

        public int UserId { get; set; }

        public ICollection<Plant> Plants { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public User User { get; set; }
    }
}


