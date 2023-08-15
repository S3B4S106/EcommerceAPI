

using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;

namespace EcommerceAPI.Dominio.Services.Ecommerce.DetalleCompra
{
    public class DetalleCompraService : ICrudService<DetalleCompraContract>
    {
        private readonly ICrudRepository<DetalleCompraEntity> _entityRepository;
        private readonly IMapper _mapper;
        public DetalleCompraService(ICrudRepository<DetalleCompraEntity> crudRepository,IMapper mapper)
        {
            _entityRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<DetalleCompraContract> CreateAsync(DetalleCompraContract entity)
        {
            DetalleCompraEntity detalleCompraEntity = await _entityRepository.CreateAsync(_mapper.Map<DetalleCompraEntity>(entity));
            return _mapper.Map<DetalleCompraContract>(detalleCompraEntity);
        }

        public async Task DeleteAsync(int id)
        {
            DetalleCompraEntity detalleCompraEntity = await _entityRepository.GetbyId(id);
            await _entityRepository.DeleteAsync(detalleCompraEntity);
        }

        public async Task<List<DetalleCompraContract>> GetAll()
        {
            List<DetalleCompraEntity> detalleCompraEntities = await _entityRepository.GetAll();
            return _mapper.Map<List<DetalleCompraContract>>(detalleCompraEntities);
        }

        public async Task<DetalleCompraContract> GetbyId(int id)
        {
            DetalleCompraEntity detalleCompraEntity = await _entityRepository.GetbyId(id);
            return _mapper.Map<DetalleCompraContract>(detalleCompraEntity);
        }

        public async Task<DetalleCompraContract> UpdateAsync(DetalleCompraContract entity)
        {
            DetalleCompraEntity detalleCompraEntity = await _entityRepository.UpdateAsync(_mapper.Map<DetalleCompraEntity>(entity));
            return _mapper.Map<DetalleCompraContract>(detalleCompraEntity);
        }
    }
}
