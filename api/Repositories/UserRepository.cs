using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Repositories.ORMLight;
using model.Db;
using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace api.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepo
    {
        
        
        List<User> _userCollection = new List<User>();
        public List<User> GetInetRequest()
        {
            
            const string url = "https://jsonplaceholder.typicode.com/posts";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            var webResponce = request.GetResponse();
            var webStream = webResponce.GetResponseStream();
            var responceReader = new StreamReader(webStream ?? throw new InvalidOperationException());
            var responce = responceReader.ReadToEnd();
            _userCollection = responce.FromJson<List<User>>();

            
            responceReader.Close();

           return _userCollection;

        }

        protected override void AddFilterOption(JoinSqlBuilder<User, User> builder)
        {
            
        }

        public UserRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }


        public List<User> GetAllList()
        {
            return new List<User>();
        }
    }
}
