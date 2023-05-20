using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SessionCookie.Models;
using SessionCookie.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SessionCookie.Controllers
{
    public class Account : Controller
    {
        [HttpGet]
       public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            List<User> dbUsers = GetAll();

            var findUserByEmail=dbUsers.FirstOrDefault(m=>m.Email == model.Email);

            if(findUserByEmail == null)
            {
                ViewBag.error = "Email or Password is wrong";
                return View(); 
            }

            if(findUserByEmail.Password!=model.Password)
            {
                ViewBag.error = "Email or Password is wrong";
                return View();
            }

            HttpContext.Session.SetString("user",JsonSerializer.Serialize(findUserByEmail));


            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }

        private List<User> GetAll()
        {
            User user1 = new()
            {
                Id = 1,
                UserName = "Resul123",
                Email = "resul@gmail.com",
                Password = "Resul123_"
            };
            User user2 = new()
            {
                Id = 2,
                UserName = "Gultac123",
                Email = "gultac@gmail.com",
                Password = "Gultac123_"
            };
            User user3 = new()
            {
                Id = 3,
                UserName = "Novreste123",
                Email = "novreste@gmail.com",
                Password = "novreste123_"
            };
            List<User> users = new() { user1, user2, user3 };
            return users;
        }
    }
}
