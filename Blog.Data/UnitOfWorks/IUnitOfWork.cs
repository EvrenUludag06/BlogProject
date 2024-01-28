using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Data.Repositories.Abstractions;
using Blog.Entity.Entities;

namespace Blog.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class,IBaseEntity, new();
        Task<int> SaveAsync();
        int Save();
    }
}
