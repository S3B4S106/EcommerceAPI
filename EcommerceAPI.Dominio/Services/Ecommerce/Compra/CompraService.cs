
using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Comunes.Classes.Helpers.General;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Clientes;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.Compra;
using EcommerceAPI.Infraestructura.Repositorios.Ecommerce.General;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Compra
{
    public class CompraService : ICrudService<CompraContract>
    {
        private readonly ICrudRepository<CompraEntity> _crudRepository;
        private readonly IMapper _mapper;
        private readonly ICrudRepository<ClienteEntity> _clienteRepository;
        private readonly ICrudRepository<EstadoEntity> _estadoRepository;
        public CompraService(
           ICrudRepository<CompraEntity> crudRepository,
           IMapper mapper,
           ICrudRepository<ClienteEntity> clienteRepository,
           ICrudRepository<EstadoEntity> estadoRepository,
           ICompraRepository compraRepository
            )
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _estadoRepository = estadoRepository;
        }
        public async Task<CompraContract> CreateAsync(CompraContract compraContract)
        {
            ClienteEntity clienteCompra = await _clienteRepository.GetbyId(compraContract.id_cliente);
            if (clienteCompra != null || compraContract.cliente != null)
            {
                if (compraContract.cliente != null)
                {
                    if (_clienteRepository.GetbyId(compraContract.cliente.id_cliente) == null)
                    {
                        ClienteEntity newClienteEntity = await _clienteRepository.CreateAsync(_mapper.Map<ClienteEntity>(compraContract.cliente));
                        compraContract.id_cliente = newClienteEntity.id_cliente;
                    }
                }
                else
                {
                    compraContract.cliente = _mapper.Map<ClienteContract>( clienteCompra);
                }
                CompraEntity compraEntity = await _crudRepository.CreateAsync(_mapper.Map<CompraEntity>(compraContract));
                CompraContract newCompraContact = _mapper.Map<CompraContract>(compraEntity);
                newCompraContact.cliente = compraContract.cliente;
                newCompraContact.estado = _mapper.Map<EstadoContract>( await _estadoRepository.GetbyId(compraContract.id_estado));
                return newCompraContact;
            }
            else
            {
                 throw new Exception("Ingrese un Cliente Valido");
            }

        }

        public async Task DeleteAsync(int id)
        {
            CompraEntity compra = await _crudRepository.GetbyId(id);
            await _crudRepository.DeleteAsync(compra);
        }

        public async Task<List<CompraContract>> GetAll()
        {
            List<CompraEntity> compraEntities = await _crudRepository.GetAll();
            List<CompraContract> CompraContracts = _mapper.Map<List<CompraContract>>(compraEntities);
            foreach (var item in CompraContracts)
            {
                CompraEntity compraEntity = _mapper.Map<CompraEntity>(item);
                item.cliente =  _mapper.Map<ClienteContract> (await _clienteRepository.GetbyId(compraEntity.id_cliente));
                item.estado = _mapper.Map<EstadoContract>(await _estadoRepository.GetbyId(compraEntity.id_estado));
            }
            return CompraContracts;
        }


        public async Task<CompraContract> GetbyId(int id)
        {
            CompraEntity compraEntity = await _crudRepository.GetbyId(id);
            CompraContract compraContract = _mapper.Map<CompraContract>(compraEntity);

            compraContract.cliente = _mapper.Map<ClienteContract>(await _clienteRepository.GetbyId(compraEntity.id_cliente));
            compraContract.estado = _mapper.Map<EstadoContract>(await _estadoRepository.GetbyId(compraEntity.id_estado));
            return compraContract;

        }

        public async Task<CompraContract> UpdateAsync(CompraContract compraContract)
        {
            ClienteEntity clienteCompra = await _clienteRepository.GetbyId(compraContract.id_cliente);
            
            if (clienteCompra != null || compraContract.cliente != null)
            {
                if (compraContract.cliente != null)
                {
                    if (_clienteRepository.GetbyId(compraContract.cliente.id_cliente) == null)
                    {
                        ClienteEntity newClienteEntity = await _clienteRepository.CreateAsync(_mapper.Map<ClienteEntity>(compraContract.cliente));
                        compraContract.id_cliente = newClienteEntity.id_cliente;
                    }
                }
                else
                {
                    compraContract.cliente = _mapper.Map<ClienteContract>(clienteCompra);
                }
                CompraEntity compraEntity = await _crudRepository.UpdateAsync(_mapper.Map<CompraEntity>(compraContract));
                CompraContract newCompraContact = _mapper.Map<CompraContract>(compraEntity);
                newCompraContact.cliente = compraContract.cliente;
                newCompraContact.estado = _mapper.Map<EstadoContract>(await _estadoRepository.GetbyId(compraContract.id_estado));
                return newCompraContact;
            }
            else
            {
                throw new Exception("Ingrese un Cliente Valido");
            }

        }
    }
}
