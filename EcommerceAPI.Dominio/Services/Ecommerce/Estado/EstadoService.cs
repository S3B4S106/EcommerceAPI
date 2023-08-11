
using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Comunes.Classes.Helpers.General;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Estado
{
    public class EstadoService : ICrudService<EstadoContract>
    {
        private readonly ICrudRepository<EstadoEntity> _crudRepository;
        private readonly IMapper _mapper;

        public EstadoService(ICrudRepository<EstadoEntity> crudRepository , IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<EstadoContract> CreateAsync(EstadoContract entity)
        {
            EstadoEntity estadoEntity = await _crudRepository.CreateAsync(_mapper.Map<EstadoEntity>(entity)); 
            return _mapper.Map<EstadoContract>(estadoEntity);
        }

        public async Task DeleteAsync(int id)
        {
            EstadoEntity estadoEntity = await _crudRepository.GetbyId(id);
            await _crudRepository.DeleteAsync(estadoEntity);
        }

        public async Task<List<EstadoContract>> GetAll()
        {
            List<EstadoEntity> estadoEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<EstadoContract>>(estadoEntities);
        }

        public async Task<EstadoContract> GetbyId(int id)
        {
            EstadoEntity estado = await _crudRepository.GetbyId(id);
            return _mapper.Map<EstadoContract>(estado);
        }

        public async Task<EstadoContract> UpdateAsync(EstadoContract entity)
        {
            EstadoEntity estado = await _crudRepository.UpdateAsync(_mapper.Map<EstadoEntity>(entity));
            return _mapper.Map<EstadoContract>(estado);
        }
    }
}
