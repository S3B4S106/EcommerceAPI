using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCompraController : ControllerBase
    {
        private readonly ICrudService<DetalleCompraContract> _service;

        public DetalleCompraController(ICrudService<DetalleCompraContract> crudService)
        {
            _service = crudService;
        }
        // GET: api/<DetalleCompraController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<DetalleCompraController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetbyId(id));
        }

        // POST api/<DetalleCompraController>
        [HttpPost]
        public async Task<IActionResult> Post(DetalleCompraContract detalleCompraContract)
        {
            return Ok(await _service.CreateAsync(detalleCompraContract));
        }

        // PUT api/<DetalleCompraController>/5
        [HttpPut]
        public async Task<IActionResult> Put(DetalleCompraContract detalleCompraContract)
        {
            return Ok(await _service.UpdateAsync(detalleCompraContract));
        }

        // DELETE api/<DetalleCompraController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
