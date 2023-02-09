using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerceBackEnd.Model
{
    public class FoodItem
    {
        [Key]
        public int foodId { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public string itemCategory { get; set; }

        public string foodImage { get; set; }
        List<Menu> Menus { get; set; }

        public OrderItem OrderItem { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
