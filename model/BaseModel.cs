using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.Interfaces;
using ServiceStack.DataAnnotations;

namespace model
{
    public class BaseModel : IBaseModel
    {  
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
