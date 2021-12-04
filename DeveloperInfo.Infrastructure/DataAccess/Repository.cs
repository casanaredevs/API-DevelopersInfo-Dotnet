using DeveloperInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperInfo.Infrastructure.DataAccess
{
    public class Repository<T, TId> : IRepository<T, TId>
        where T : class, IEntityBase<TId>
    {

        protected DbContext Context { get; }
        protected DbSet<T> DbSet { get; }

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(TId id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
                throw new NotImplementedException();
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }

        public IQueryable<T> Query()
        {
            return DbSet.AsQueryable();
        }

        public async Task<IList<T>> GetAll()
        {
            return await DbSet.AsQueryable().ToListAsync();
        }

        public async Task<T> GetAsync(TId id)
        {
            return await DbSet.FindAsync(id) ?? throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
