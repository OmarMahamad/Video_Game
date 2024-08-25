using Microsoft.AspNetCore.Mvc;
using Video_Game.Areas.GamersArea.Models;
using Video_Game.Data;
using Video_Game.Models;

namespace Video_Game.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        private readonly CardDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly gamesmodel _gamesmodel;
        private readonly UsersModel _user;

        public AdminController(CardDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _gamesmodel=new gamesmodel(_context,_environment);
            _user = new UsersModel(context);
        }




        public IActionResult Home()
        {
            ViewBag.game = _gamesmodel.ShowAll();
            return View();
        }
        
        
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(Games games,IFormFile? image)
        {
            games.Rating = 0;
            games.ReleaseDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                if (_gamesmodel.AddImage(games,image))
                {
                    return RedirectToAction("Home");
                }
                ViewBag.Error = "this game is eardy find";
            }
            return View();
        }

        [HttpGet]
        public IActionResult DetilesGame(int id)
        {
            _gamesmodel.DitelsGame(id);
            return View();
        }




    }
}
