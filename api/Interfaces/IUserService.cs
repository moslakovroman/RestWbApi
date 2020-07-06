using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.Db;

namespace api.Interfaces
{
    public interface IUserService
    {
        void AddUsers(List<User> users);

        List<User> FinalUsersInetList();
        List<User> GetUserInfo();
    }
}
