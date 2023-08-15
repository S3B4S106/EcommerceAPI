
using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Infraestructura.Database.Entities;

namespace EcommerceAPI.Configuracion.Inicial
{
    public class PerfilAutoMapper : Profile
    {
        public PerfilAutoMapper() 
        {
            CreateMap<ClienteEntity, ClienteContract>().ReverseMap();
            CreateMap<CompraEntity, CompraContract>().ReverseMap();
            CreateMap<EstadoEntity, EstadoContract>().ReverseMap();
            CreateMap<ProductoEntity,ProductoContract>().ReverseMap();
        }
    }
}
