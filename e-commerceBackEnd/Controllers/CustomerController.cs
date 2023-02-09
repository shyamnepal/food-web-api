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
    public class CustomerController : ControllerBase
    {
        public readonly NormalDbContext _appDbContext;
       public CustomerController(NormalDbContext normalDbContext)
        {
            _appDbContext = normalDbContext;
        }

        [HttpPost("Customer-post")]
        public IActionResult CustomerPost([FromBody] CustomerDto customerDto)
        {
            try
            {
                Customer obj = new Customer();
                obj.email = customerDto.email;
                obj.phoneNum = customerDto.phoneNum;
                obj.fName = customerDto.fName;
                obj.lName = customerDto.lName;

                _appDbContext.tbl_Customer.Add(obj);
                _appDbContext.SaveChanges();

                return Ok(obj);

            }catch(Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("customer-get")]
        public async Task<ActionResult<List<Customer>>> CustomerGet()
        {
            try
            {
                var customer = await _appDbContext.tbl_Customer
                    //.Where(o => o.CustomerId == id)
                    .Include(c => c.Orders)
                    .Include(p => p.Payments)
                    .ToListAsync();

                return customer;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

    }
}
