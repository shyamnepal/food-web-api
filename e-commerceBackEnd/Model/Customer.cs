using System.ComponentModel.DataAnnotations;

namespace e_commerceBackEnd.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
         public string email { get; set; }
         public string phoneNum { get; set; }
         public string fName { get; set; } 
         public string lName { get; set; }
         public List<Order> Orders { get; set; }
         public List<Payment> Payments { get; set; }

         
         

        
         

        
    }
}
