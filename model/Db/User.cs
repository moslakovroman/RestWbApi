using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.Interfaces;
using ServiceStack.DataAnnotations;

namespace model.Db
{
    public class User : BaseModel
    {   /*[Alias("tbluserzzz")]*/
        [AutoIncrement]
        //public int IdFromPage { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

       
    }
}
