

namespace EcommerceAPI.Comunes.Classes.Contracts.Ecommerce
{
    public class DetalleCompraContract
    {
        public int id_detallecompra { get; set; }
        public int cantidad { get; set; }
        public decimal valorunitario { get; set; }
        public int id_compra { get; set; }
        public int id_producto { get; set; }
    }
}
