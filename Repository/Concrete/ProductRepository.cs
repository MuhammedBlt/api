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
     public class ProductRepository : Repository<Product>, IProductRepository
     {
        private readonly ICustomerRepository _categoryRespository;

         public ProductRepository(MyDbContext myDbContext) : base(myDbContext)
         {
         }

         public async Task<Product?> GetProductByName(string productName)
         {
             return await _dbSet.FirstOrDefaultAsync(x => x.ProductName == productName);
         }
     }
 }