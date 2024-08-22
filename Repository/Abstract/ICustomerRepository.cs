using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;

namespace api.Repository.Abstract
{
    public interface ICustomerRepository :IRepository<Customer>
    {
        Task<Product?> GetCustomerByName(string customerName);
    }
}