using e_commerceBackEnd.Data;
using e_commerceBackEnd.Model;
using e_commerceBackEnd.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly NormalDbContext _appDbContext;
            public OrderController(NormalDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpPost("Order-post")]
        public IActionResult OrderPost([FromBody] OrdersDto ordersDto)
        {
            try
            {
                Order order = new Order();
                order.quantity = ordersDto.quantity;
                order.pickUpDate = ordersDto.pickUpDate;
                order.orderDate = ordersDto.orderDate;
                order.CustomerId = ordersDto.CustomerId;

                _appDbContext.tbl_Order.Add(order);
                _appDbContext.SaveChanges();

                return Ok(order);

               

            }catch(Exception ex)
            {
                return Ok(ex);
            }

           


        }
        [HttpGet("OrderGet")]
        public async Task<ActionResult<List<Order>>> OrgerGet(int id)
        {
            try
            {
                var order = await _appDbContext.tbl_Order
                    .Where(o => o.orderID == id)
                    .Include(c => c.OrderItem)
                    .Include(p=> p.Payment)
                    .ToListAsync();

                return order;
            }catch(Exception ex)
            {
                return Ok(ex);
            }
           
        }
    }
}
