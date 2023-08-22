
using EcommerceAPI.Infraestructura.Database.Entities;

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Compra
{
    public interface ICompraRepository
    {
        Task<List<CompraEntity>> GetByCliente(int id);
    }
}
