using e_commerceBackEnd.Data;
using e_commerceBackEnd.Model;
using e_commerceBackEnd.Model.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly NormalDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(NormalDbContext appDbContext, IHttpContextAccessor HttpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = HttpContextAccessor;
        }


        [Authorize]
        [HttpPost("Product-post")]
        public IActionResult product([FromBody] Product request)
        {
            ProductDto pro = new ProductDto();
            try
            {
               
                pro.name = request.name;
                pro.price = request.price;
                pro.descriptionn = request.descriptionn;

                _appDbContext.Add(pro);
                _appDbContext.SaveChanges();

                var name = _httpContextAccessor.HttpContext.User.FindFirst("id").Value;
                return Ok( name);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            
            

        }

    }
}
