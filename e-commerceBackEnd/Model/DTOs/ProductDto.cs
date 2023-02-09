using System.ComponentModel.DataAnnotations;

namespace e_commerceBackEnd.Model.DTOs
{
    public class ProductDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string descriptionn { get; set; }
        [Required]
        public double price { get; set; }
    }
}
