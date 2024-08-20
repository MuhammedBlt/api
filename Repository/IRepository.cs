using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.Repository
{
    public interface IRepository<T> where T: class
    {
        Task <IEnumerable<T>> GetAllAsync();
        Task<T>GetByIdAsync(int id);
        Task UpdateAsync (T entity);
        Task DeleteAsync (T entity);
        Task<T> AddAsync(T entity);
    }
}