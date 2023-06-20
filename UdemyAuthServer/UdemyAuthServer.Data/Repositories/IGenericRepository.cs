using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UdemyAuthServer.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        void Remove(T entity);

        T Update(T entity);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}