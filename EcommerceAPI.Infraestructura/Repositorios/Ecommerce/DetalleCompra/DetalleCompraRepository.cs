

using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.DetalleCompra
{
    public class DetalleCompraRepository : ICrudRepository<DetalleCompraEntity>
    {
        private readonly EcommerceContext  _context;
        public DetalleCompraRepository(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<DetalleCompraEntity> CreateAsync(DetalleCompraEntity entity)
        {
            _context.DetalleCompra.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(DetalleCompraEntity entity)
        {
            _context.DetalleCompra.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DetalleCompraEntity>> GetAll()
        {
            return await _context.DetalleCompra.ToListAsync();
        }

        public async Task<DetalleCompraEntity> GetbyId(int id)
        {
            return await _context.DetalleCompra
                .FirstOrDefaultAsync(m=> m.id_detallecompra == id);
            
        }

        public async Task<DetalleCompraEntity> UpdateAsync(DetalleCompraEntity entity)
        {
            _context.DetalleCompra.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
