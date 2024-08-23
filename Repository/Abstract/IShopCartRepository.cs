using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repository.Abstract
{
    public interface IShopCartRepository:IRepository<ShopCart>
    {
        Task<ShopCart> GetByIdAsync(int id);
        Task<List<CartItem>> GetCartItemsByShopCartIdAsync(int shopCartId);
        Task RemoveCartItemsAsync(List<CartItem> items);
    }
}
