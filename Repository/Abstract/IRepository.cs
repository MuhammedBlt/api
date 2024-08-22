using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Abstract;

namespace api.Repository.Abstract
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