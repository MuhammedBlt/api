 using api.Entities.Concrete;
 using api.Repository.Abstract;
 using api.Repository.Concrete;
 using api.ViewModel;
 using Microsoft.AspNetCore.Mvc;


 namespace api.Controllers
 {
     [Route("[controller]")]
     public class ProductWithGenericRepoController : Controller
     {
         protected readonly IProductRepository _productRespository;
 
         public ProductWithGenericRepoController(IProductRepository productRespository)
         {
             _productRespository = productRespository;
         }
 
         [HttpGet]
         public async Task<IActionResult> Get(){
             var product= await _productRespository.GetAllAsync();
             return Ok(product);
         }
         [HttpGet("{id}")]
         public async Task<IActionResult> GetById(int id)
         {
             var product = await _productRespository.GetByIdAsync(id);
             if (product == null)
             {
                 return NotFound();
             }
             return Ok(product);
         }
         [HttpPost]
         public async Task<IActionResult> Post([FromBody] ProductRequest product)
         {
             if (string.IsNullOrWhiteSpace(product.ProductName)){
                 return BadRequest($"{product.ProductName} Urun ismi Dolu olmak zorunda");

             }
             if (product.ProductPrice <= 0){
                     return Ok();
             }
             var entity= await _productRespository.GetProductByName(product.ProductName);
             if (entity is not null){
                 return BadRequest("Urun daha Once eklendi");
             }
            
             var productEntity = new Product()
             {
                 ProductName = product.ProductName,
                 ProductPrice = product.ProductPrice,
             };
             var createdProductReponse = await _productRespository.AddAsync(productEntity);
             return CreatedAtAction(nameof(GetById), new { id = createdProductReponse.ProductId }, createdProductReponse);
 
         }
         [HttpPut("{id}")]
         public async Task<ActionResult> Put(int id, [FromBody] ProductRequest product)
         {
             var productEntity = await _productRespository.GetByIdAsync(id);
             if (productEntity == null)
             {
                 return NotFound();
 
             }
             productEntity.ProductName = product.ProductName;
             productEntity.ProductPrice = product.ProductPrice;
             await _productRespository.UpdateAsync(productEntity);
             return NoContent();
 
 
         }
         [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(int id)
         {
             var product = await _productRespository.GetByIdAsync(id);
             if (product == null)
             {
                 return NotFound();
 
             }
             await _productRespository.DeleteAsync(product);
             return NoContent();
 
         }
     }
 }