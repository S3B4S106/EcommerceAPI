

using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Comunes.Classes.Helpers.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Login
{
    public class LoginService : ILoginService
    {
        private readonly IClientesRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ICifradoHelper _cifradoHelper;
        public LoginService(IClientesRepository clientesRepository, IMapper mapper, ICifradoHelper  cifradoHelper)
        {
            _clienteRepository = clientesRepository;
            _mapper = mapper;
            _cifradoHelper = cifradoHelper;

        }
        public async Task<ClienteContract> Login(LoginContract loginContract)
        {
            ClienteEntity cliente = await _clienteRepository.LoginCliente(loginContract.Email, _cifradoHelper.EncryptString(loginContract.Password));
            if (cliente != null)
            {
                return _mapper.Map<ClienteContract>(cliente);
                
            }else
            {
                throw new UnauthorizedAccessException("Usuario y/o contraseña no son validos, por favor  vuelva a intentar."); 
            }
        }
    }
}
