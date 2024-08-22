using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ICategoryRepository _categoryRespository;

        public CategoryRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        public async Task<Category?> GetCategoryByName(string categoryName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.CategoryName == categoryName);
        }
    }
}
