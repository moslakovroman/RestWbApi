using ServiceStack.OrmLite;

namespace api.Repositories.ORMLight
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IDbConnectionFactory Factory { get; set; }

        public UnitOfWorkProvider(IDbConnectionFactory factory)
        {
            Factory = factory;
        }

        public virtual IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(Factory);
        }
    }
}