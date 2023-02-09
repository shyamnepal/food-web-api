namespace e_commerceBackEnd.Model.DTOs
{
    public class OrdersDto
    {
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public int quantity { get; set; }
        public int CustomerId { get; set; }

        public DateTime pickUpDate { get; set; }

      //  public Payment Payment { get; set; }

       // public OrderItem OrderItem { get; set; }


    }
}
