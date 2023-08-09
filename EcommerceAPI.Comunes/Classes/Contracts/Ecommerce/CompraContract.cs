

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Comunes.Classes.Contracts.Ecommerce
{
    public class CompraContract
    {
        public int id_compra { get; set; }
        public DateTime fecha_compra { get; set; }
        public decimal valor_total { get; set; }
        public string direccionentrega { get; set; }

        //public int id_estado { get; set; }

        // public EstadoEntity estado { get; set; } = null;

        //public int id_cliente { get; set; }
        public ClienteContract cliente { get; set; } = null;


    }
}
