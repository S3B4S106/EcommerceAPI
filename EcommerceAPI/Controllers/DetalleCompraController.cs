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
    public class DetalleCompraController : Controller
    {
        private readonly ICrudService<DetalleCompraContract> _service;

        public DetalleCompraController(ICrudService<DetalleCompraContract> crudService)
        {
            _service = crudService;
        }
        // GET: api/<DetalleCompraController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<DetalleCompraController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetbyId(id));
        }

        // POST api/<DetalleCompraController>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Post(DetalleCompraContract detalleCompraContract)
        {
            return Ok(await _service.CreateAsync(detalleCompraContract));
        }

        // PUT api/<DetalleCompraController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Put(DetalleCompraContract detalleCompraContract)
        {
            return Ok(await _service.UpdateAsync(detalleCompraContract));
        }

        // DELETE api/<DetalleCompraController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
