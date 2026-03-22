using System.Linq.Expressions;

namespace ItemShop.Cargo.DAL.Abstracts
{
    public interface IGenericDAL<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}