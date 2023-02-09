namespace e_commerceBackEnd.Model.DTOs
{
    public class FoodItemDto
    {
      
        public string name { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public string itemCategory { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}
