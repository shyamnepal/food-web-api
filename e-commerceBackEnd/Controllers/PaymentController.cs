using e_commerceBackEnd.Data;
using e_commerceBackEnd.Model.DTOs;
using e_commerceBackEnd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        public readonly NormalDbContext _appDbContext;
        public PaymentController(NormalDbContext normalDbContext)
        {
            _appDbContext = normalDbContext;
        }

        [HttpPost("Payment-post")]
        public IActionResult CustomerPost([FromBody] PaymentDto paymentDto)
        {
            try
            {
                Payment obj = new Payment();
                obj.amount = paymentDto.amount;
                obj.paymentDate = paymentDto.paymentDate;
                obj.paymentType = paymentDto.paymentType;
                obj.paymentDate = paymentDto.paymentDate;
                obj.orderId = paymentDto.orderId;
                
               

                _appDbContext.tbl_Payment.Add(obj);
                _appDbContext.SaveChanges();

                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("payment-get")]
        public async Task<ActionResult<List<Payment>>> CustomerGet()
        {
            try
            {
                var payment = await _appDbContext.tbl_Payment
                    //.Where(o => o.CustomerId == id)
                    .Include(c => c.Customer)
                    .Include(p => p.Order)
                    .ToListAsync();

                return payment;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
    }
}
