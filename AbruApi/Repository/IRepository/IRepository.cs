using System.Linq.Expressions;

namespace AbruApi.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked=true);
        Task<T> CreatAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
