using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;
using api.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class OrderWithGenericRepoController:Controller
    {
        private readonly IRepository<Order> _orderRespository;
        public OrderWithGenericRepoController(IRepository<Order> orderRespository)
        {
            _orderRespository = orderRespository;
           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderRespository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}