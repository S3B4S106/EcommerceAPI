

namespace EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General
{
   
    public interface ICrudRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetbyId(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
