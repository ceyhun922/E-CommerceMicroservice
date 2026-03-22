

using System.Linq.Expressions;
using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ItemShop.Cargo.DAL.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private readonly CargoContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CargoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
                
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}