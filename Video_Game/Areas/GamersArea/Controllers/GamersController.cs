using Microsoft.AspNetCore.Mvc;
using Video_Game.Areas.GamersArea.Models;
using Video_Game.Data;
using Video_Game.Models;

namespace Video_Game.Areas.GamersArea.Controllers
{
    [Area("GamersArea")]
    public class GamersController : Controller
    {
        private readonly CardDbContext _context;
        private readonly  IWebHostEnvironment _environment;
        private gamesmodel _gamesmodel;
        public GamersController(CardDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _gamesmodel = new gamesmodel(_context, _environment);
        }

        private Gamer FindUser()
        {
            var id = HttpContext.Session.GetInt32("userid");
            if (id != null)
            {
                return _context.Gamers.Find(id);
            }
            return null;
        }

        



        public IActionResult Home()
        {
            var newgame = _gamesmodel.newgame();

            ViewBag.User = FindUser();
            ViewBag.game = newgame;
            return View();
        }
        

        public IActionResult Game()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SershBy(string name)
        {
            var game = _gamesmodel.SerchBy(name);
            if (game != null)
            {
                ViewBag.game = game;
                return RedirectToAction("Game");
            }
            return View("Game");
        }




    }
}
