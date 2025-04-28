using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        // Queries (Veri Çekme İşlemleri)
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp);

        // Command (Veri Manipülasyon İşlemleri)
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T originalEntity, T newEntity);
    }
}
