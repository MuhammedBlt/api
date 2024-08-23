using System.Threading.Tasks;
using api.Entities.Concrete;

namespace api.Repository.Abstract
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<Order> AddAsync(Order order);
        Task<Order> GetByIdAsync(int id);
    }
}
