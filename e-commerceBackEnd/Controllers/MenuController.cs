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
    public class MenuController : ControllerBase
    {
        public readonly NormalDbContext _appDbContext;
        public MenuController(NormalDbContext normalDbContext)
        {
            _appDbContext = normalDbContext;
        }

        [HttpPost("Menu-post")]
        public IActionResult CustomerPost([FromBody] MenuDto menuDto)
        {
            try
            {
                Menu obj = new Menu();
                obj.foodId = menuDto.foodId;
                obj.price = menuDto.price;
                obj.startDate = menuDto.startDate;
                


                _appDbContext.tbl_Menu.Add(obj);
                _appDbContext.SaveChanges();

                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("Menu-get")]
        public IActionResult getMenu()
        {
            try
            {
                var menu = _appDbContext.tbl_Menu
                .Include(f => f.FoodItem)
                .ToList();

                return Ok(menu);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
            
                
        }
       

    }
}
