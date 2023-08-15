

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities
{
    [Table("DetalleCompra")]
    public class DetalleCompraEntity
    {
        [Key]
        public int id_detallecompra { get; set; }
        public int cantidad { get; set; }
        public decimal valorunitario { get; set; }
        [ForeignKey("id_compra")]
        public int id_compra { get; set;}
        [ForeignKey("id_producto")]
        public int id_producto { get; set; }
        
    }
}
