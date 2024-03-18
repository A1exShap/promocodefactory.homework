using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Domain;

namespace Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRepository<T>
        where T: BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);

        Task<bool> UpdateAsync(Guid id, T entity);

        Task<bool> DeleteAsync(Guid id);
    }
}