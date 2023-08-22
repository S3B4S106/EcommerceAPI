
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities
{
    [Table("Compra")]
    public class CompraEntity
    {
        [Key]
        public int id_compra { get; set; }
        public int id_cliente { get; set; }
        [ForeignKey("id_cliente")]
        public int id_estado { get; set; }
        [ForeignKey("id_estado")]
        public DateTime fecha_compra { get; set; }
        public decimal valor_total { get; set; }
        public string direccionentrega { get; set; }
    }
}
