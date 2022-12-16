using WorkFlowManager.Common.DataAccess.Repositories;
using System;
using System.Data.Entity;

namespace WorkFlowManager.Common.DataAccess._UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        int Complete();
        DbContext GetContext();
    }
}
