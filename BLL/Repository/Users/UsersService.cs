using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Domain;

namespace BLL.Repository.Users
{
    public class UsersService : IUsersService
    {
        private BOL.DBContext.SetServiceDbContext _context;

        public UsersService()
        {
            _context = new BOL.DBContext.SetServiceDbContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            var query = from u in _context.Users select u;

            return query;

        }

        public User GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            var query = _context.Users.Find(id);

            return query;
        }


        public void UpdateUser(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
