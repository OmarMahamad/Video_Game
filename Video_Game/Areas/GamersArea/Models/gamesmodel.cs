using Video_Game.Data;
using Video_Game.Models;
using Microsoft.AspNetCore.Mvc;

namespace Video_Game.Areas.GamersArea.Models
{
    public class gamesmodel
    {

        private readonly IWebHostEnvironment _environment;
        private readonly CardDbContext _context;

        public gamesmodel(CardDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        public List<Games> ShowAll()
        {
            return _context.Games.ToList();
        } 
        
        public bool AddImage(Games games, IFormFile? gameimg)
        {
            var check = _context.Games.FirstOrDefault(g=>g.Titel==games.Titel);
            if (check == null)
            {
                if (gameimg != null)
                {
                    Guid guid = Guid.NewGuid();
                    string ext = Path.GetExtension(gameimg.FileName);
                    string fullname = guid + ext;
                    games.ImagePath = "\\gamer\\gamesImg\\" + fullname;
                    string fullpath = _environment.WebRootPath + games.ImagePath;
                    FileStream fileStream = new FileStream(fullpath, FileMode.Create);
                    gameimg.CopyTo(fileStream);
                    fileStream.Dispose();
                }
                _context.Games.Add(games);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public List<Games> SerchBy(string name)
        {
            var sersh = _context.Games.Where(g=>g.Titel==name)
                .ToList();
            if (sersh!=null)
            {
                return sersh;
            }
            return sersh;
        }

        public List<Games> newgame()
        {
            var games = _context.Games
                .Where(g => g.ReleaseDate<DateTime.Now)
                .ToList();
            if (games != null)
            {
                return games;
            }
            return games;
        }


        public bool AddGame(Games games)
        {
            var check = _context.Games.FirstOrDefault(g=>g.Titel==games.Titel);
            if (check == null)
            {

                _context.Games.Add(games);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        
        public Games DitelsGame(int id)
        {
            var check = _context.Games.Find(id);
            if (check != null)
            {
                return check;
            }
            return null;
        }

        public bool EditGame(Gamer gamer,int id)
        {
            var check = _context.Games.Find(id);
            if (check != null)
            {
                _context.Gamers.Update(gamer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveGame(int id)
        {
            var check = _context.Games.Find(id);
            if (check != null)
            {
                _context.Games.Remove(check);
                _context.SaveChanges();
                return true;
            }
            return false;
        }







    }
}
