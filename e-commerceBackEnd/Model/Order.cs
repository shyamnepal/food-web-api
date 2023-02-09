using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace e_commerceBackEnd.Model
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public int quantity { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public DateTime pickUpDate { get; set; }

        public Payment Payment { get; set; }

        public OrderItem OrderItem { get; set; }



    }
}
