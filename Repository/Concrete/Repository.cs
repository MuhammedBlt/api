using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using api.Repository.Concrete; 


namespace api.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbSet<T> _dbSet;
        public readonly MyDbContext _myDbContext;
        public Repository(MyDbContext myDbContext)
        { _dbSet=myDbContext.Set<T>();
         _myDbContext=myDbContext;
         }

        public async Task<T> AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
            await _myDbContext.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
             _myDbContext.Entry(entity).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync(); 
        }
    }
 }
 

             