
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities
{
    public class ProductoEntity
    {
        [Key] 
        public int id_producto { get; set; }
        public string descripcion { get; set; }

        public decimal valor { get; set; }

        public string? imagen { get; set; } = "";
        public int id_estado { get; set; }
        [ForeignKey("id_estado")]
        public int stock { get; set; }

    }
}
