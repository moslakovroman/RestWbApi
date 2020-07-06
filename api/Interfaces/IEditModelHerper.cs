using System.Collections.Generic;
using model.Db;
using model.ViewModels;

namespace api.Interfaces
{
    public interface IEditModelHerper
    {
        List<User> GetUserInfo();
        EditViewModel GetEditUser(int id);
        void SaveEditUser(EditViewModel model);
        User CancelEditUser(EditViewModel model);
    }
}