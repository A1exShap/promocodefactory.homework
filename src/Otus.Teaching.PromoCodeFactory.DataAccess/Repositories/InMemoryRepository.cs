using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T>
        : IRepository<T>
        where T: BaseEntity
    {
        protected ICollection<T> Data { get; set; }

        public InMemoryRepository(ICollection<T> data)
        {
            Data = data;
        }
        
        public Task<ICollection<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<T> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();

            Data.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> UpdateAsync(Guid id, T entity)
        {
            var existingEntity = Data.FirstOrDefault(x => x.Id == id);
            
            if (existingEntity is null) 
                return Task.FromResult(false);

            entity.Id = id;

            Data.Remove(existingEntity);
            Data.Add(entity);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var existingEntity = Data.FirstOrDefault(x => x.Id == id);

            if (existingEntity is null)
                return Task.FromResult(false);

            return Task.FromResult(Data.Remove(existingEntity));
        }
    }
}