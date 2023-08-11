using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly ICrudService<EstadoContract> _crudService;
        public EstadoController(ICrudService<EstadoContract> crudRepository)
        {
            _crudService = crudRepository;
        }
        // GET: api/<EstadoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _crudService.GetAll());
        }

        // GET api/<EstadoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _crudService.GetbyId(id));
        }

        // POST api/<EstadoController>
        [HttpPost]
        public async Task<IActionResult> Post(EstadoContract estado)
        {
            return Ok(await _crudService.CreateAsync(estado));
        }

        // PUT api/<EstadoController>/5
        [HttpPut]
        public async Task<IActionResult> Put(EstadoContract estado)
        {
            return Ok(await _crudService.UpdateAsync(estado));
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _crudService.DeleteAsync(id);
            return Ok();
        }
    }
}
