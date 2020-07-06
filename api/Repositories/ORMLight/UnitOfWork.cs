using System;
using System.Data;
using ServiceStack.OrmLite;

namespace api.Repositories.ORMLight
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }
            if (Transaction != default(IDbTransaction))
            {
                Transaction.Dispose();
            }
            if (DB != default(IDbConnection))
            {
                DB.Dispose();
            }

            disposed = true;
            GC.SuppressFinalize(this);
            
        }
        ~UnitOfWork()
        {
            Dispose();
        }

        public IDbConnection DB { get; set; }
        public IDbTransaction Transaction { get; private set; }
        private bool disposed = false;

        public UnitOfWork(IDbConnectionFactory dbFactory)
        {
            DB = dbFactory.Open();
            Transaction = DB.OpenTransaction();

        }


        public virtual void Save()
        {
            Transaction.Commit();
        }


    }
}