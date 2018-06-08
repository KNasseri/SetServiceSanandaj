using BOL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Users
{
    public interface IUsersService
    {
        IQueryable<User> GetAllUsers();

        User GetUserById(string id);

        void UpdateUser(User user);
    }
}
