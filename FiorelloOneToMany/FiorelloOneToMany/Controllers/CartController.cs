using FiorelloOneToMany.Data;
using FiorelloOneToMany.Models;
using FiorelloOneToMany.VıewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace FiorelloOneToMany.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public CartController(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public async Task<IActionResult> Index()
        {
            List<BasketDetailVm> basketList = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
              List<BasketVM> basketDatas =JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
                foreach (var item in basketDatas)
                {
                    var dbProduct = await _context.Products.Include(m => m.Image).FirstOrDefaultAsync(m=>m.Id==item.Id);

                    if(dbProduct != null)
                    {
                        BasketDetailVm basketDetail = new()
                        {
                            Id = dbProduct.Id,
                            Name = dbProduct.Name,
                            Image = dbProduct.Image.FirstOrDefault(),
                            Count = item.Count,
                            Price = dbProduct.Price,
                            TotalPrice = dbProduct.TotalPrice
                        };
                    }

           
                }

            }



            return View(basketList);
        }
    }
}
