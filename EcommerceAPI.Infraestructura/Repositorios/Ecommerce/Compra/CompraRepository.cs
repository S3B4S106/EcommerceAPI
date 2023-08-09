
using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Compra
{
    public class CompraRepository : ICrudRepository<CompraEntity>
    {
        private readonly EcommerceContext _context;

        public CompraRepository(EcommerceContext context)
        {
            _context = context;
        }
        public Task<CompraEntity> CreateAsync(CompraEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CompraEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompraEntity>> GetAll()
        {
            return await _context.Compra.ToListAsync();
        }

        public Task<CompraEntity> GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CompraEntity> UpdateAsync(CompraEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
