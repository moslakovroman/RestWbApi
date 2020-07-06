using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using model.Db;
using ServiceStack.OrmLite;

namespace api
{
    public class ApiConfig : IConfig
    {
        private IDbConnectionFactory _factory;

        public ApiConfig(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Configure()
        {
            InitDatabase();
        }

        public void InitDatabase()
        {
            using (var db = _factory.OpenDbConnection())
            {
                db.CreateTableIfNotExists(
                    typeof(User).Assembly.GetTypes()
                    .Where(t => t.IsClass && t.Namespace != null && t.Name != null && t.Namespace.Equals("model.Db")).ToArray());
            }
        }
    }
}
