

using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Comunes.Classes.Helpers.General;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Clientes
{
    public class ClientesService : ICrudService<ClienteContract>
    {
        private readonly ICrudRepository<ClienteEntity> _crudRepository;
        private readonly IClientesRepository _clientesRepository;
        private readonly IMapper _mapper;
        private readonly ICifradoHelper _cifradoHelper;
        public ClientesService(
           ICrudRepository<ClienteEntity>crudRepository,
           IClientesRepository clientesRepository,
           IMapper mapper,
           ICifradoHelper cifradoHelper
            ) 
        {
            _crudRepository = crudRepository;
            _clientesRepository = clientesRepository;
            _mapper = mapper;
            _cifradoHelper = cifradoHelper;
        }

        /// <summary>
        /// Metodo para crear clientes en la base de datos
        /// </summary>
        /// <param name="entity">El objeto con los datos del cliente</param>
        /// <returns>El ciente creado y si no el cliente que ya existe</returns>
        public async Task<ClienteContract> CreateAsync(ClienteContract entity)
        {
            ClienteEntity cliente = await _clientesRepository.GetByEmail(entity.correo);
            if( cliente == null )
            {
                entity.contrasena = _cifradoHelper.EncryptString(entity.contrasena);
                cliente = await _crudRepository.CreateAsync(_mapper.Map<ClienteEntity>(entity));
               return _mapper.Map<ClienteContract>(cliente);
            }
            else
            {
                return _mapper.Map<ClienteContract>(cliente);
            }
        }
        /// <summary>
        /// Metodo para eliminar cliente de la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            ClienteEntity cliente = await _crudRepository.GetbyId(id);
            if( cliente != null )
            {
                await _crudRepository.DeleteAsync(cliente);
            }
        }
        /// <summary>
        /// Metodo para obtener todos los clientes
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClienteContract>> GetAll()
        {
            List<ClienteEntity> clienteEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<ClienteContract>>(clienteEntities);
        }

        public async Task<ClienteContract> GetbyId(int id)
        {
            ClienteEntity cliente = await _crudRepository.GetbyId(id);
            return _mapper.Map<ClienteContract>(cliente);
        }

        public async Task<ClienteContract> UpdateAsync(ClienteContract entity)
        {
            ClienteEntity cliente = await _crudRepository.UpdateAsync(_mapper.Map<ClienteEntity> (entity));
            return _mapper.Map<ClienteContract>(cliente);
        }
    }
}
