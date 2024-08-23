// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using api.Entities.Concrete;
// using api.Repository.Abstract;
// using api.ViewModel;
// using Microsoft.AspNetCore.Mvc;

// namespace api.Controllers
// {
//      [Route("[controller]")]
//      public class AdminWithGenericRepoController : ControllerBase
//      {
//          protected readonly IAdminRepository _adminRespository;
 
//          public AdminWithGenericRepoController(IAdminRepository adminRespository)
//          {
//              _adminRespository = adminRespository;
//          }
 
//          [HttpGet]
//          public async Task<IActionResult> Get(){
//              var admin= await _adminRespository.GetAllAsync();
//              return Ok(admin);
//          }
//          [HttpGet("{id}")]
//          public async Task<IActionResult> GetById(int id)
//          {
//              var admin = await _adminRespository.GetByIdAsync(id);
//              if (admin == null)
//              {
//                  return NotFound();
//              }
//              return Ok(admin);
//          }
//          [HttpPost]
//          public async Task<IActionResult> Post([FromBody] AdminRequest admin)
//          {
//              if (string.IsNullOrWhiteSpace(admin.AdminName)){
//                  return BadRequest($"{admin.AdminName} Urun ismi Dolu olmak zorunda");

//              }
             
             
            
//              var adminEntity = new Admin()
//              {
//                  AdminName = admin.AdminName,
//                  AdminId = admin.AdminId,
//              };
//              var createdAdminReponse = await _adminRespository.AddAsync(adminEntity);
//              return CreatedAtAction(nameof(GetById), new { id = createdAdminReponse.AdminId }, createdAdminReponse);
 
//          }
//          [HttpPut("{id}")]
//          public async Task<IActionResult> Put([FromBody] AdminRequest admin)
//         {
//             var adminEntity = new Admin()
//             {
//                 AdminName = admin.AdminName,
                
            
//             };
//             var createdAdminReponse = await _adminRespository.AddAsync(adminEntity);
//             return CreatedAtAction(nameof(GetById), new { id = createdAdminReponse.AdminId }, createdAdminReponse);
 
//         }
 
         
//          [HttpDelete("{id}")]
//          public async Task<IActionResult> Delete(int id)
//          {
//              var admin = await _adminRespository.GetByIdAsync(id);
//              if (admin == null)
//              {
//                  return NotFound();
 
//              }
//              await _adminRespository.DeleteAsync(admin);
//              return NoContent();
 
//          }
// }}
