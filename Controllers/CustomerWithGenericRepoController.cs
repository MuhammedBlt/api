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
    public class CustomerWithGenericRepoController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRespository;
        public CustomerWithGenericRepoController(IRepository<Customer> customerRespository)
        {
            _customerRespository = customerRespository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _customerRespository.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerRespository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequest customer)
        {
            var customerEntity = new Customer()
            {
                CustomerName = customer.CustomerName,

            };
            var createdCustomerReponse = await _customerRespository.AddAsync(customerEntity);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomerReponse.CustomerId }, createdCustomerReponse);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CustomerRequest customer)
        {
            var customerEntity = await _customerRespository.GetByIdAsync(id);
            if (customerEntity == null)
            {
                return NotFound();

            }
            customerEntity.CustomerName = customer.CustomerName;
            await _customerRespository.UpdateAsync(customerEntity);
            return NoContent();


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRespository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();

            }
            await _customerRespository.DeleteAsync(customer);
            return NoContent();

        }
    }
}
