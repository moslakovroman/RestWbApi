using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using api.Interfaces;
using model.Db;
using model.Filters;
using model.ViewModels;
using ServiceStack.Html;


namespace api.Services
{
    public class EditModelHelper : IEditModelHerper
    {
        private readonly IUserRepo _userRepo;
        

        public EditModelHelper(IUserRepo userRepo)
        {
            _userRepo = userRepo;
           
        }

        

        public List<User> GetUserInfo()
        {
            BaseFilter baseFilter = new BaseFilter();
            var users = _userRepo.GetByFilter(baseFilter);
            var item = from user in users
                select new User()
                {
                    Id = user.Id,
                    UserId = user.UserId,
                    Title = user.Title,
                    Body = user.Body,
                    Created = user.Created,
                    Updated = user.Updated
                };
            return item.ToList();

            
        }

        public EditViewModel GetEditUser(int id)
        {
            var editUser = _userRepo.Get(id);
            EditViewModel item = new EditViewModel()
            {
                Id = editUser.Id,
                EditUserId = editUser.UserId,
                EditTitle = editUser.Title,
                EditBody = editUser.Body,
                Created = editUser.Created,
                Updated = editUser.Updated
            };
            return item;

            
        }

        public void SaveEditUser(EditViewModel model)
        {
            var userDbModel = _userRepo.Get(model.Id);
            //userDbModel.Id = model.Id;
            userDbModel.UserId = model.EditUserId;
            userDbModel.Title = model.EditTitle;
            userDbModel.Body = model.EditBody;
            userDbModel.Created = model.Created;
            userDbModel.Updated = model.Updated;
            
            _userRepo.Save(userDbModel);
        }

        public User CancelEditUser(EditViewModel model)
        {
            var userDbModel = _userRepo.Get(model.Id);
            return userDbModel;
        }
    }
}