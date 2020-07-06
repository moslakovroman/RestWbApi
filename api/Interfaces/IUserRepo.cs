using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces.IBaseRepository;
using model.Db;

namespace api.Interfaces
{
    public interface IUserRepo : IBaseRepository<User>
    {
        

        List<User> GetInetRequest();
    }


}
