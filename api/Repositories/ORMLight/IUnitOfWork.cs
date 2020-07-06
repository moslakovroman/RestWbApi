using System;
using System.Data;

namespace api.Repositories.ORMLight
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection DB { get; set; }
        void Save();
    }
}