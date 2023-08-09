

using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Comunes.Classes.Helpers.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Login
{
    public class LoginService : ILoginService
    {
        private readonly IClientesRepository _clienteRepository;
        private readonly IConfiguration _configuration;
        private readonly ICifradoHelper _cifradoHelper;
        public LoginService(IClientesRepository clientesRepository, IConfiguration configuration, ICifradoHelper  cifradoHelper)
        {
            _clienteRepository = clientesRepository;
            _configuration = configuration;
            _cifradoHelper = cifradoHelper;

        }
        public async Task<string> Login(LoginContract loginContract)
        {
            ClienteEntity cliente = await _clienteRepository.LoginCliente(loginContract.Email, _cifradoHelper.EncryptString(loginContract.Password));
            if (cliente != null)
            {
                return JWTHelper.GenerarToken(cliente.nombre,_configuration);
                
            }else
            {
                throw new UnauthorizedAccessException("Usuario y/o contraseña no son validos, por favor  vuelva a intentar."); 
            }
        }
    }
}
