

using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes
{
    public class ClientesRepository : ICrudRepository<ClienteEntity>, IClientesRepository
    {
        private readonly EcommerceContext _context;

        public ClientesRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<ClienteEntity> CreateAsync(ClienteEntity entity)
        {
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(ClienteEntity entity)
        {
            _context.Clientes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClienteEntity>> GetAll()
        {
            return await _context.Clientes.ToListAsync();   
        }

        public async Task<ClienteEntity> GetByEmail(string email)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(m => m.correo == email);
        }

        public async Task<ClienteEntity> GetbyId(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(m=> m.id_cliente == id);
        }

        public async Task<ClienteEntity> LoginCliente(string email, string password)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(entidad=>entidad.correo == email && entidad.contrasena == password );
            throw new NotImplementedException();
        }

        public async Task<ClienteEntity> UpdateAsync(ClienteEntity entity)
        {
            _context.Clientes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
