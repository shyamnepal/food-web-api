namespace e_commerceBackEnd.Model.DTOs
{
    public class PaymentDto
    {
        public int paymentId { get; set; }
  
        public int? CustomerId { get; set; }
       

        public int? orderId { get; set; }
        public DateTime paymentDate { get; set; }
        public double amount { get; set; }
        public string paymentType { get; set; }
    }
}
