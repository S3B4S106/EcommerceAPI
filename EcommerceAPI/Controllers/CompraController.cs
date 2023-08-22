using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly ICrudService<CompraContract> _service;

        public CompraController(ICrudService<CompraContract> service)
        {
            _service = service;
        }
        // GET: api/<CompraController>
        [HttpGet]
        [Route("GetAll")]

        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<CompraController>/5
        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetbyId(id));
        }

        // POST api/<CompraController>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Post(CompraContract compra)
        {
            return Ok(await _service.CreateAsync(compra));
        }

        // PUT api/<CompraController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Update(CompraContract contract)
        {
            return Ok(await _service.UpdateAsync(contract));
        }

        // DELETE api/<CompraController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
