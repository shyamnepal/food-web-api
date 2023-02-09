using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerceBackEnd.Model.DTOs
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
  
        public int orderID { get; set; }
       
       
        public int? foodId { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
    }
}
