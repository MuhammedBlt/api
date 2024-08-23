using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.Repository.Concrete
{
    public class OrderRepository : Repository<Order>
    {
        private readonly MyDbContext _context;
        public readonly DbSet<Order> _dbSet;

        public OrderRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            _context = myDbContext;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
