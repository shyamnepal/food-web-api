using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerceBackEnd.Model
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public Order Order { get; set; }
        public int orderID { get; set; }
        public FoodItem FoodItem { get; set; }
        [ForeignKey(nameof(FoodItem))]
        public int? foodId { get; set; }
        public int quantity { get; set; }
        public double unitPrice {get;set;}
    }
}
