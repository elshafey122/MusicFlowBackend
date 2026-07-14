using Microsoft.EntityFrameworkCore;
using ProductService.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Persistence.Repositories
{
    public class Repository<T> : IRepositroy<T> where T : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
           _context = context;    
        }
        public async Task AddAsync(T entity)
        {
            var result = await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entites)
        {
            var result = _context.AddRangeAsync(entites);
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
        }
        
        public async Task DeleteRange(IEnumerable<T> entites)
        {
            _context.RemoveRange(entites);
        }

        public async Task UpdateAsync(T entity)
        {
            var result = _context.Update(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public IQueryable<T> GetTableTracking()
        {
            return _context.Set<T>().AsTracking();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<int> SaveChanges()
        {
            var res = await _context.SaveChangesAsync();
            return res;
        }
        
    }
}
