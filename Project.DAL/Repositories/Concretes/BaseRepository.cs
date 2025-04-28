using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        readonly MyContext _context;
        readonly DbSet<T> _dbSet;

        protected BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Asenkron Query’ler
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.Where(exp).ToListAsync();
        }

        // Asenkron Command’lar
        public virtual async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T originalEntity, T newEntity)
        {
            _context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
            await _context.SaveChangesAsync();
        }
    }
}
