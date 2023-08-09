

using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Login
{
    public interface ILoginService
    {
        /// <summary>
        /// Metodo para autenticar un cliente
        /// </summary>
        /// <param name="email">parametro de consulta</param>
        /// <param name="password">parametro de consulta</param>
        /// <returns>retorna el objeto cliente</returns>
        Task<ClienteContract>Login(LoginContract loginContract);
    }
}
