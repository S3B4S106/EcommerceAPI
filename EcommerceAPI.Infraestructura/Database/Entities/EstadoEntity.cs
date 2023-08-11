

using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Infraestructura.Database.Entities
{
    public class EstadoEntity
    {
        [Key]
        public int id_estado { get; set; }
        public string descripcion { get; set; }
        public string esquema { get; set; }
    }
}
