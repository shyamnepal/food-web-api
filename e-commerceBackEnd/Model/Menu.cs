using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerceBackEnd.Model
{
    public class Menu
    {
        [Key]
        public int menuId { get; set; }
        public double price { get; set; }
        public DateTime startDate { get; set; }

        public FoodItem FoodItem { get; set; }
        [ForeignKey(nameof(FoodItem))]
        public int foodId { get; set; }

    }
}
