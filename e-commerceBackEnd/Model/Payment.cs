using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerceBackEnd.Model
{
    public class Payment
    {
        [Key]
        public int paymentId { get; set; }
        public Customer Customer { get; set; }

        public int? CustomerId { get; set; }
        public Order Order { get; set; }
        
        public int? orderId { get; set; }

        public DateTime paymentDate { get; set; }
        public double amount { get; set; }
        public string paymentType { get; set; }

    }
}
