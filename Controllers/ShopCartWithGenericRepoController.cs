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
   [ApiController]
    [Route("api/[controller]")]
    public class ShopCartWithGenericRepoController : ControllerBase
    {
        private readonly IRepository<ShopCart> _shopCartRespository;
        public ShopCartWithGenericRepoController(IRepository<ShopCart> shopCartRespository)
        {
            _shopCartRespository = shopCartRespository;
           
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var categories= await _shopCartRespository.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shopCart = await _shopCartRespository.GetByIdAsync(id);
            if (shopCart == null)
            {
                return NotFound();
            }
            return Ok(shopCart);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartRequest shopCart)
        {
            var shopCartEntity = new ShopCart()
            {
                CustomerId = shopCart.CustomerId,
                Quantity=shopCart.Quantity,


            
            };
            var createdShopCartReponse = await _shopCartRespository.AddAsync(shopCartEntity);
            return CreatedAtAction(nameof(GetById), new { id = createdShopCartReponse.ShopCartId }, createdShopCartReponse);
 
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CartRequest shopCart)
        {
            var shopCartEntity = await _shopCartRespository.GetByIdAsync(id);
            if (shopCartEntity == null)
            {
                return NotFound();
 
            }
           
            await _shopCartRespository.UpdateAsync(shopCartEntity);
            return NoContent();
 
 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shopCart = await _shopCartRespository.GetByIdAsync(id);
            if (shopCart == null)
            {
                return NotFound();
 
            }
            await _shopCartRespository.DeleteAsync(shopCart);
            return NoContent();
 
        }
    }
}   