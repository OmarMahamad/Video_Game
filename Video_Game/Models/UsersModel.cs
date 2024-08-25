using Microsoft.EntityFrameworkCore;
using Video_Game.Data;

namespace Video_Game.Models
{
    public class UsersModel
    {
        private readonly CardDbContext _context;
        public UsersModel(CardDbContext context)
        {
            _context = context;
        }

        public object Login(string Email, string PassWord)
        {
            var chekAdmin = _context.Admins.FirstOrDefault(a => a.Email == Email && a.Password == PassWord);
            var chekGamer = _context.Gamers.FirstOrDefault(a => a.Email == Email && a.Password == PassWord);

            if (chekGamer != null)
            {
                return chekGamer;
            }

            if (chekAdmin != null)
            {
                return chekAdmin;
            }

            return null;
        }
        public bool AddUser<T>(T user) where T : User
        {
            var dbSet = _context.Set<T>();
            var check = dbSet.FirstOrDefault(u => u.Email == user.Email);

            if (check == null)
            {
                dbSet.Add(user);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Edit<E>(E user,int id) where E : User
        {
            var dbset = _context.Set<E>();

            var check = dbset.Find(id); 
            if (check != null)
            {
                dbset.Update(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public object Detil<D>(int id)where D : User   
        {
            var dbset= _context.Set<D>();
            var check = dbset.Find(id);
            if (check != null)
            {
                return check;
            }

            return null;
        }
        public bool Delete<D>(int id) where D : User
        {
            var dbset=_context.Set<D>();
            var check = dbset.Find(id); 
            if (check != null)
            {
                _context.Remove(check);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
