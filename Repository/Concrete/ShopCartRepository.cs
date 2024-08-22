using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;

namespace api.Repository.Concrete
{
    public class ShopCartRepository : Repository<ShopCart>, IShopCartRepository
    {
        private readonly IShopCartRepository _shopCartRespository;

        public ShopCartRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}