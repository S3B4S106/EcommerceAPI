
using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Comunes.Classes.Helpers.General;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Compra
{
    public class CompraService : ICrudService<CompraContract>
    {
        private readonly ICrudRepository<CompraEntity> _crudRepository;
        private readonly IMapper _mapper;
        public CompraService(
           ICrudRepository<CompraEntity> crudRepository,
           IMapper mapper
            )
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }
        public Task<CompraContract> CreateAsync(CompraContract entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompraContract>> GetAll()
        {
            List<CompraEntity> compraEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<CompraContract>>(compraEntities);
        }

        public Task<CompraContract> GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CompraContract> UpdateAsync(CompraContract entity)
        {
            throw new NotImplementedException();
        }
    }
}
