using api.Entities.Concrete;
using api.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderWithGenericController : ControllerBase
    {
        private readonly IShopCartRepository _shopCartRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderWithGenericController(IShopCartRepository shopCartRepository, IOrderRepository orderRepository)
        {
            _shopCartRepository = shopCartRepository;
            _orderRepository = orderRepository;
        }


        [HttpPost("CreateOrderFromCart")]
        public async Task<IActionResult> CreateOrderFromCart([FromBody] int shopCartId)
        {
            if (shopCartId <= 0)
            {
                return BadRequest("Invalid ShopCart ID.");
            }

            
            var shopCart = await _shopCartRepository.GetByIdAsync(shopCartId);
            if (shopCart == null)
            {
                return NotFound("ShopCart not found.");
            }

            var cartItems = await _shopCartRepository.GetCartItemsByShopCartIdAsync(shopCartId);
            if (!cartItems.Any())
            {
                return NotFound("No items found in the shop cart.");
            }

            
            var order = new Order
            {
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Product = ci.Product,
                    Quantity = ci.Quantity
                }).ToList()
            };

            
            var createdOrder = await _orderRepository.AddAsync(order);

            
            await _shopCartRepository.RemoveCartItemsAsync(cartItems);

            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
