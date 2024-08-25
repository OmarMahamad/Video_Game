
using Microsoft.AspNetCore.Mvc;
using Video_Game.Data;
using Video_Game.Models;

namespace Video_Game.Controllers
{
    public class UserController : Controller
    {
        private readonly CardDbContext _context;
        private UsersModel _user;
        public UserController(CardDbContext context) { 
            _context = context;
            _user = new UsersModel(_context);
        }
        
        public IActionResult Login()
        {
            return View();
        } 

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string PassWord)
        {
            var user = _user.Login(Email, PassWord);

            switch (user)
            {
                case Gamer gamer:
                    HttpContext.Session.SetInt32("userid", gamer.GamerID);
                    return RedirectToAction("Home", "Gamers", new { area = "GamersArea" });

                case Admin admin:
                    HttpContext.Session.SetInt32("userid", admin.AdminID);
                    return RedirectToAction("Home", "Admin", new { area = "Admin" });

                default:
                    ViewBag.Error = "The Email or Password is incorrect";
                    return View();
            }
        }

        [HttpPost]
        public IActionResult Register(Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                if (_user.AddUser(gamer))
                {
                    HttpContext.Session.SetInt32("userid", gamer.GamerID);
                    return RedirectToAction("Home", "Gamers", new { area = "GamersArea" });
                }
            }
            ViewBag.Error = "The Email is ready Register";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }




    }
}
