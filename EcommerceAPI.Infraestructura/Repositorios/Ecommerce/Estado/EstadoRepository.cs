

using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Estado
{
    public class EstadoRepository : ICrudRepository<EstadoEntity>
    {
        private readonly EcommerceContext _context;
        public EstadoRepository(EcommerceContext context) 
        { 
          _context = context;
        }
        public async Task<EstadoEntity> CreateAsync(EstadoEntity entity)
        {   _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(EstadoEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EstadoEntity>> GetAll()
        {
            return await _context.Estado.ToListAsync();
        }

        public async Task<EstadoEntity> GetbyId(int id)
        {
            return await _context.Estado
                .FirstOrDefaultAsync(m=>m.id_estado==id);
        }

        public async Task<EstadoEntity> UpdateAsync(EstadoEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
