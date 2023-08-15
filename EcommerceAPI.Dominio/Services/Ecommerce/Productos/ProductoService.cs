
using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Productos
{
    public class ProductoService : ICrudService<ProductoContract>
    {
        private readonly ICrudRepository<ProductoEntity> _repository;
        private readonly IMapper _mapper;
        public ProductoService(ICrudRepository<ProductoEntity> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductoContract> CreateAsync(ProductoContract entity)
        {
            ProductoEntity productoEntity = await _repository.CreateAsync(_mapper.Map<ProductoEntity>(entity));
            return _mapper.Map<ProductoContract>(productoEntity);
        }

        public async Task DeleteAsync(int id)
        {
            ProductoEntity productoEntity = await _repository.GetbyId(id);
            await _repository.DeleteAsync(productoEntity);
        }

        public async Task<List<ProductoContract>> GetAll()
        {
            List<ProductoEntity> productoEntities = await _repository.GetAll();
            return _mapper.Map<List<ProductoContract>>(productoEntities);
        }

        public async Task<ProductoContract> GetbyId(int id)
        {
            ProductoEntity productoEntity = await _repository.GetbyId(id);
            return _mapper.Map<ProductoContract>(productoEntity);
        }

        public async Task<ProductoContract> UpdateAsync(ProductoContract entity)
        {
            ProductoEntity productoEntity = await _repository.UpdateAsync(_mapper.Map<ProductoEntity>(entity));
            return _mapper.Map<ProductoContract>(productoEntity);
        }
    }
}
