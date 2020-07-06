using System;
using System.Collections.Generic;
using api.Interfaces.IBaseRepository;
using api.Repositories.ORMLight;
using model;
using model.Filters;
using ServiceStack.OrmLite;
using api.Interfaces.IBaseRepository;

namespace api.Repositories
{
    public abstract class BaseRepository <T> where T : BaseModel, new()
    {
        private IUnitOfWorkProvider UnitOfWorkProvider { get; set; }

        public List<T> GetByFilter(BaseFilter filter)
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                var builder = new JoinSqlBuilder<T,T>();

                if (filter.Id.HasValue)
                {
                    builder.Where<T>(x => x.Id == filter.Id);
                }

                if (filter.Created.HasValue)
                {
                    builder.Where<T>(x => x.Created == filter.Created);
                }

                if (filter.Updated.HasValue)
                {
                    builder.Where<T>(x => x.Updated == filter.Updated);
                }

                AddFilterOption(builder);

                return unitOfWork.DB.Select<T>(builder.ToSql());
            }
        }

        protected virtual void AddFilterOption(JoinSqlBuilder<T, T> builder)
        {

        }


        protected BaseRepository(IUnitOfWorkProvider provider)
        {
            UnitOfWorkProvider = provider;
        }

        public virtual T Save(T item)
        {
            using (var  unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                return Save(item, unitOfWork);
            }
        }

        public virtual T Get(int id)
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                return Get(id, unitOfWork);
            }
        }

        public virtual List<T> GetList()
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                return GetAllList(unitOfWork);
            }
        }

        private List<T> GetAllList( IUnitOfWork unitOfWork)
        {
            return unitOfWork.DB.GetList<T>(null, new object[] { });
        }

        private T Get(int id, IUnitOfWork unitOfWork)
        {
            return unitOfWork.DB.GetByIdOrDefault<T>(id);
        }

        private T Save(T item, IUnitOfWork unitOfWork)
        {
            if (item.Id != 0)
            {
                item.Updated = DateTime.UtcNow;
                unitOfWork.DB.Update(item);
            }
            else
            {
                item.Created = DateTime.UtcNow;

                unitOfWork.DB.Insert(item);
                item.Id = (int) unitOfWork.DB.GetLastInsertId();
            }

            unitOfWork.Save();
            return Get(item.Id);
        }
    }
}