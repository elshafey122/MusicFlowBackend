using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Persistence.IRepositories
{
    public interface IRepositroy<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableTracking();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entites);
        Task AddRangeAsync(IEnumerable<T> entity);
        Task<int> SaveChanges();
    }
}
