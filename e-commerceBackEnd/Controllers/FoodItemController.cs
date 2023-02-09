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
    public class FoodItemController : ControllerBase
    {
        public readonly NormalDbContext _appDbContext;
        public static Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public FoodItemController(NormalDbContext normalDbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _appDbContext = normalDbContext;
            _environment = environment;
        }

        [HttpPost]
        public async Task<FoodItem> Post([FromForm] FoodItemDto files)

        {
            FoodItem food = new FoodItem();



            if (files.ImageFile.Length > 0)
            {
                try
                {

                    string name = new String(Path.GetFileNameWithoutExtension(files.ImageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    name = name + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(files.ImageFile.FileName);
                    food.foodImage = "\\uploads\\" + name;

                    food.unitPrice = files.unitPrice;
                    food.itemCategory = files.itemCategory;
                    food.name = files.name;
                    food.quantity = files.quantity;
                   

                    _appDbContext.tbl_FoodItem.Add(food);
                    _appDbContext.SaveChanges();





                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + name))
                    {
                        files.ImageFile.CopyTo(filestream);
                        filestream.Flush();
                        // return "\\uploads\\" + files.files.FileName;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return await Task.FromResult(food);
            }
            else
            {
                return await Task.FromResult(food);
            }

        }

        [HttpGet("Food-Item")]
        public IActionResult FoodItemGet()
        {
            try
            {
                var foodItem = _appDbContext.tbl_FoodItem
                       .Include(o => o.OrderItem)
                       .ToList();

                return Ok(foodItem);
            }catch(Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
