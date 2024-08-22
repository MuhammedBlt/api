using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;

namespace api.Repository.Concrete
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IOrderRepository _orderRespository;

        public OrderRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}