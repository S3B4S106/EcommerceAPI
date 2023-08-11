
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Comunes.Classes.Contracts.Ecommerce
{
    public class EstadoContract
    {
        public int id_estado { get; set; }
        public string descripcion { get; set; }
        public string esquema { get; set; }
    }
}
