using FiorelloOneToMany.Data;
using FiorelloOneToMany.Models;
using FiorelloOneToMany.VıewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FiorelloOneToMany.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context= context;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Expert>experts=await _context.Experts.Include(m=>m.Position).Where(m=>m.SoftDelete).ToListAsync();

            IEnumerable<Product> products = await _context.Products.Include(m => m.Image).Where(m => m.SoftDelete).ToListAsync();

            HomeVM home = new()
            {
                Experts = experts,
                Products= products
            };
            return View(home);
        }
      
        
   
    }
}