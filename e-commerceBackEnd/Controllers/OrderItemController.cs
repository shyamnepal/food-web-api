using e_commerceBackEnd.Data;
using e_commerceBackEnd.Model.DTOs;
using e_commerceBackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerceBackEnd.Controllers
{
    public class OrderItemController : Controller
    {
        public readonly NormalDbContext _appDbContext;
        public OrderItemController(NormalDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpPost("OrderItem-post")]
        public IActionResult OrderPost([FromBody] OrderItemDto ordersItemDto)
        {
            try
            {
                OrderItem orderitem = new OrderItem();
                orderitem.quantity = ordersItemDto.quantity;
                orderitem.unitPrice = ordersItemDto.unitPrice;
                orderitem.foodId = ordersItemDto.foodId;
                orderitem.orderID = ordersItemDto.orderID;

                _appDbContext.OrderItem.Add(orderitem);
                _appDbContext.SaveChanges();

                return Ok(orderitem);



            }
            catch (Exception ex)
            {
                return Ok(ex);
            }




        }

        [HttpGet("OrderItem-Get")]
        public async Task<ActionResult<List<OrderItem>>> OrgerGet(int id)
        {
            try
            {
                var order = await _appDbContext.OrderItem
                    .Where(o => o.OrderItemId == id)
                    .Include(c => c.FoodItem)
                    .Include(p => p.Order)
                    .ToListAsync();

                return order;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
    }
}
