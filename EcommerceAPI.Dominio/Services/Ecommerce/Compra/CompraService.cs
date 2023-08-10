
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
        public async Task<CompraContract> CreateAsync(CompraContract entity)
        {
           CompraEntity compra =  await _crudRepository.CreateAsync(_mapper.Map<CompraEntity>(entity));
            return _mapper.Map<CompraContract>(compra);
        }

        public async Task DeleteAsync(int id)
        {
            CompraEntity compra = await _crudRepository.GetbyId(id);
            await _crudRepository.DeleteAsync(compra);
        }

        public async Task<List<CompraContract>> GetAll()
        {
            List<CompraEntity> compraEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<CompraContract>>(compraEntities);
        }

        public async Task<CompraContract> GetbyId(int id)
        {
            CompraEntity compra = await _crudRepository.GetbyId(id);
            return _mapper.Map<CompraContract>(compra);

        }

        public async Task<CompraContract> UpdateAsync(CompraContract entity)
        {
            CompraEntity compra = await _crudRepository.UpdateAsync(_mapper.Map<CompraEntity>(entity));
            return _mapper.Map<CompraContract>(compra);
        }
    }
}
