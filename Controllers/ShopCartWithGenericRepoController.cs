using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;
using api.Repository.Abstract;
using api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("[controller]")]
    public class ShopCartWithGenericRepoController : Controller
    {
        
        private readonly IShopCartRepository _shopCartRespository;
        public ShopCartWithGenericRepoController(IShopCartRepository shopCartRespository)
         {
             _shopCartRespository = shopCartRespository;
         }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShopCartRequest shopCart)
        {
            if (shopCart.CustomerId == 0 || shopCart.ProductId == 0)
            {
                return BadRequest($"Musteri ve Urun dolu olmak zorunda");

            }
            var shopCartEntity = new ShopCart()
            {

                ProductId = shopCart.ProductId,
                CustomerId = shopCart.CustomerId,
                ShopCartQuantity = shopCart.ShopCartQuantity,
                ShopCartTotal = shopCart.ShopCartTotal
            };
            var createdShopCartReponse = await _shopCartRespository.AddAsync(shopCartEntity);
            return CreatedAtAction(nameof(GetById), new { id = createdShopCartReponse.ShopCartId }, createdShopCartReponse);

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _shopCartRespository.GetAllAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _shopCartRespository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}