namespace Jacaranda.Domain.Model
{
    public class Payment : BaseModel
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }

        public string PaymentRequest { get; set; }
        public string PaymentResponse { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}


