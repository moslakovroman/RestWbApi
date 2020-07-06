using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Interfaces
{
    public interface IBaseModel
    {
         int Id { get; set; }
         DateTime Created { get; set; }
         DateTime? Updated { get; set; }
    }
}
