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
    public class ProductoController : Controller
    {
        private readonly ICrudService<ProductoContract> _service;
        public ProductoController(ICrudService<ProductoContract> service)
        {
            _service = service;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<ProductoController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetbyId(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Post(ProductoContract productoContract)
        {
            return Ok(await _service.CreateAsync(productoContract));
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Put(ProductoContract productoContract)
        {
            return Ok(await _service.UpdateAsync(productoContract));
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
