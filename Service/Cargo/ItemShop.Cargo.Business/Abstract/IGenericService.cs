using System.Linq.Expressions;

namespace ItemShop.Cargo.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> GetAllServiceAsync();
        Task<List<T>> GetAllServiceFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdServiceAsync(int id);
        Task InsertServiceAsync(T entity);
        Task UpdateServiceAsync(T entity);
        Task DeleteServiceAsync(int id);
    }
}