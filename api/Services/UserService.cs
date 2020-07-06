using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using model.Db;
using model.ViewModels;
using ServiceStack.OrmLite;
using ServiceStack.Text;


namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IEditModelHerper _editModelHerper;

        public UserService(IUserRepo userRepo, IEditModelHerper editModelHerper)
        {
            _userRepo = userRepo;
            _editModelHerper = editModelHerper;
        }

        public void AddUsers(List<User> users)
        {
            foreach (var item in users)
            {
                _userRepo.Save(item);
            }
        }

        public List<User> FinalUsersInetList()
        {
            return _userRepo.GetInetRequest();
        }

        public List<User> GetUserInfo()
        {
            return _editModelHerper.GetUserInfo();
        }

        public EditViewModel GetEditUserService(int id)
        {
            return _editModelHerper.GetEditUser(id);
        }
    }
}
