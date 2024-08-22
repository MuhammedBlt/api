using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Entities.Concrete;
using api.Repository.Abstract;
using api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryWithGenericRepoController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRespository;
        public CategoryWithGenericRepoController(IRepository<Category> categoryRespository)
        {
            _categoryRespository = categoryRespository;
           
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var categories= await _categoryRespository.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRespository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryRequest category)
        {
            var categoryEntity = new Category()
            {
                CategoryName = category.CategoryName,
            
            };
            var createdCategoryReponse = await _categoryRespository.AddAsync(categoryEntity);
            return CreatedAtAction(nameof(GetById), new { id = createdCategoryReponse.CategoryId }, createdCategoryReponse);
 
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryRequest category)
        {
            var categoryEntity = await _categoryRespository.GetByIdAsync(id);
            if (categoryEntity == null)
            {
                return NotFound();
 
            }
            categoryEntity.CategoryName = category.CategoryName;
            await _categoryRespository.UpdateAsync(categoryEntity);
            return NoContent();
 
 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRespository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
 
            }
            await _categoryRespository.DeleteAsync(category);
            return NoContent();
 
        }
    }
}

    