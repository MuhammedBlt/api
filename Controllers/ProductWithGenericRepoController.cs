using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Repository;
using api.Entities;
using api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("[controller]")]
    public class ProductWithGenericRepoController : Controller
    {
        private readonly ILogger<ProductWithGenericRepoController> _logger;
        private readonly IRepository<Product> _productRespository;

        public ProductWithGenericRepoController(ILogger<ProductWithGenericRepoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public ProductWithGenericRepoController(IRepository<Product> productRespository)
        {
            _productRespository=productRespository;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var products= await _productRespository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var product = await _productRespository.GetByIdAsync(id);
            if (product == null){
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest product)
        {
            var productEntity = new Product(){
                ProductName=product.ProductName,
                Price=product.Price,
            };
            var createdProductReponse  = await _productRespository.AddAsync(productEntity);
            return CreatedAtAction(nameof(GetById),new {id=createdProductReponse.ProductId},createdProductReponse);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody]ProductRequest product){
            var productEntity = await _productRespository.GetByIdAsync(id);
            if(productEntity == null){
                return NotFound();

            }
            productEntity.ProductName = product.ProductName;
            productEntity.Price = product.Price;
            await _productRespository.UpdateAsync(productEntity);
            return NoContent();


        }
        public async Task<IActionResult> Delete(int id){
            var product = await _productRespository.GetByIdAsync(id);
            if (product == null){
                return NotFound();

            }
            await _productRespository.DeleteAsync(product);
            return NoContent();

        }
    }
}