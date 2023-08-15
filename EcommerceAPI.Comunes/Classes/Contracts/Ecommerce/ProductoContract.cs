
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Comunes.Classes.Contracts.Ecommerce
{
    public class ProductoContract
    {
        public int id_producto { get; set; }
        public string descripcion { get; set; }

        public decimal valor { get; set; }

        public string imagen { get; set; }
        public int id_estado { get; set; }
    
        public int stock { get; set; }
    }
}
