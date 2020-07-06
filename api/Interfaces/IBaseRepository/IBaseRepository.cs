using System.Collections.Generic;
using model.Filters;

namespace api.Interfaces.IBaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        T Save(T item);
        T Get(int id);
        List<T> GetAllList();
        List<T> GetByFilter(BaseFilter filterObject);
    }
}