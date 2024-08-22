using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;

namespace api.Repository.Concrete
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ICustomerRepository _categoryRespository;
        public CustomerRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        public Task<Product?> GetCustomerByName(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}