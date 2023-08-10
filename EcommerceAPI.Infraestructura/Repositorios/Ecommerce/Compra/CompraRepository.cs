
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
        public async Task<CompraEntity> CreateAsync(CompraEntity entity)
        {
            _context.Compra.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(CompraEntity entity)
        {
            _context.Compra.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompraEntity>> GetAll()
        {
            return await _context.Compra.ToListAsync();
        }

        public async Task<CompraEntity> GetbyId(int id)
        {
            return await _context.Compra.
            FirstOrDefaultAsync(m => m.id_compra == id);
        }

        public async Task<CompraEntity> UpdateAsync(CompraEntity entity)
        {
            _context.Compra.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
