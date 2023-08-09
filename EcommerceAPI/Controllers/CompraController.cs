using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompraController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
