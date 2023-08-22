using AutoMapper;
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
    public class EstadoController : Controller
    {
        private readonly ICrudService<EstadoContract> _crudService;
        public EstadoController(ICrudService<EstadoContract> crudRepository)
        {
            _crudService = crudRepository;
        }
        // GET: api/<EstadoController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _crudService.GetAll());
        }

        // GET api/<EstadoController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _crudService.GetbyId(id));
        }

        // POST api/<EstadoController>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Post(EstadoContract estado)
        {
            return Ok(await _crudService.CreateAsync(estado));
        }

        // PUT api/<EstadoController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Put(EstadoContract estado)
        {
            return Ok(await _crudService.UpdateAsync(estado));
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _crudService.DeleteAsync(id);
            return Ok();
        }
    }
}
