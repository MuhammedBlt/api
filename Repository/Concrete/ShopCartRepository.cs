using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repository.Concrete
{
    public class ShopCartRepository :Repository<ShopCart>, IShopCartRepository
    {
        private readonly MyDbContext _context;
        public readonly DbSet<Order> _dbSet;

        public ShopCartRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            _context = myDbContext;
        }

        public async Task<ShopCart> GetByIdAsync(int id)
        {
            return await _context.ShopCarts
                .Include(sc => sc.CartItems)
                .FirstOrDefaultAsync(sc => sc.ShopCartId == id);
        }

        public async Task<List<CartItem>> GetCartItemsByShopCartIdAsync(int shopCartId)
        {
            return await _context.CartItems
                .Where(ci => ci.ShopCartId == shopCartId)
                .ToListAsync();
        }

        public async Task RemoveCartItemsAsync(List<CartItem> items)
        {
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
