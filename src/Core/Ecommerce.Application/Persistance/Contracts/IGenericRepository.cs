using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();
        Task<bool> Exisit(int id);
    }
}
