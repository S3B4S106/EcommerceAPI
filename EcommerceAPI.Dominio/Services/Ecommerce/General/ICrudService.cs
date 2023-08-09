

namespace EcommerceAPI.Dominio.Services.Ecommerce.General
{
    public interface ICrudService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetbyId(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
