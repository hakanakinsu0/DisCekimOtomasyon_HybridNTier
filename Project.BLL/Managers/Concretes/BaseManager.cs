using AutoMapper;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : BaseDto where U : class, IEntity
    {
        protected readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        protected BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Sorgulama İşlemleri (Queries)

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(entities);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(entity);
        }

        public virtual List<T> GetActives()
        {
            var entities = _repository
                .WhereAsync(e => e.Status != DataStatus.Deleted)
                .GetAwaiter()
                .GetResult();
            return _mapper.Map<List<T>>(entities);
        }

        public virtual List<T> GetPassives()
        {
            var entities = _repository
                .WhereAsync(e => e.Status == DataStatus.Deleted)
                .GetAwaiter()
                .GetResult();
            return _mapper.Map<List<T>>(entities);
        }

        public virtual List<T> GetModifieds()
        {
            var entities = _repository
                .WhereAsync(e => e.Status == DataStatus.Updated)
                .GetAwaiter()
                .GetResult();
            return _mapper.Map<List<T>>(entities);
        }

        #endregion

        #region Komut İşlemleri (Commands - CRUD)

        public virtual async Task CreateAsync(T dto)
        {
            var entity = _mapper.Map<U>(dto);
            await _repository.CreateAsync(entity);
        }

        public virtual async Task UpdateAsync(T dto)
        {
            var original = await _repository.GetByIdAsync(dto.Id);
            if (original == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID={dto.Id} not found.");

            var updated = _mapper.Map<U>(dto);
            await _repository.UpdateAsync(original, updated);
        }

        public virtual async Task<string> RemoveAsync(T dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return $"{typeof(T).Name} with ID={dto.Id} not found.";

            await _repository.RemoveAsync(entity);
            return $"{typeof(T).Name} with ID={dto.Id} removed successfully.";
        }

        public virtual async Task MakePassiveAsync(T dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID={dto.Id} not found.");

            entity.Status = DataStatus.Deleted;
            entity.DeletedDate = DateTime.Now;
            await _repository.UpdateAsync(entity, entity);
        }

        public virtual async Task CreateRangeAsync(List<T> dtoList)
        {
            foreach (var dto in dtoList)
            {
                var entity = _mapper.Map<U>(dto);
                await _repository.CreateAsync(entity);
            }
        }

        public virtual async Task UpdateRangeAsync(List<T> dtoList)
        {
            foreach (var dto in dtoList)
            {
                var original = await _repository.GetByIdAsync(dto.Id);
                if (original == null) continue;

                var updated = _mapper.Map<U>(dto);
                await _repository.UpdateAsync(original, updated);
            }
        }

        public virtual async Task<string> RemoveRangeAsync(List<T> dtoList)
        {
            int removedCount = 0;
            foreach (var dto in dtoList)
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity != null)
                {
                    await _repository.RemoveAsync(entity);
                    removedCount++;
                }
            }
            return $"{removedCount} of {dtoList.Count} {typeof(T).Name}(s) removed.";
        }

        #endregion

        #region Aggregate İşlemleri

        public virtual async Task<int> CountAsync(Expression<Func<U, bool>> predicate = null)
        {
            if (predicate != null)
            {
                var filtered = await _repository.WhereAsync(predicate);
                return filtered.Count;
            }
            else
            {
                var all = await _repository.GetAllAsync();
                return all.Count;
            }
        }

        public virtual async Task<decimal> SumAsync(
            Expression<Func<U, decimal>> selector,
            Expression<Func<U, bool>> predicate = null)
        {
            IEnumerable<U> items;
            if (predicate != null)
                items = await _repository.WhereAsync(predicate);
            else
                items = await _repository.GetAllAsync();

            return items.AsQueryable().Sum(selector);
        }

        #endregion
    }
}
