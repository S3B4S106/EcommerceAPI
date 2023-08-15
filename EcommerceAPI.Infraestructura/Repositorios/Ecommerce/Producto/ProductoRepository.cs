
using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Producto
{
    public class ProductoRepository : ICrudRepository<ProductoEntity>
    {
        private readonly EcommerceContext _context;
        public ProductoRepository(EcommerceContext ecommerceContext)
        {
            _context = ecommerceContext;
        }

        public async Task<ProductoEntity> CreateAsync(ProductoEntity entity)
        {
            _context.Producto.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(ProductoEntity entity)
        {
            _context.Producto.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductoEntity>> GetAll()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<ProductoEntity> GetbyId(int id)
        {
            return await _context.Producto
                .FirstOrDefaultAsync(m => m.id_producto == id);
        }

        public async Task<ProductoEntity> UpdateAsync(ProductoEntity entity)
        {
            _context.Producto.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
