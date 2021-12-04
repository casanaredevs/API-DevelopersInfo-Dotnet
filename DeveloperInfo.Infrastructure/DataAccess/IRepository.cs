using DeveloperInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperInfo.Infrastructure.DataAccess
{
    public interface IRepository<T,TId>
        where T : class, IEntityBase<TId>
    {
        IQueryable<T> Query();
        Task<IList<T>> GetAll();
        Task<T> GetAsync(TId id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(TId id);
    }
}
