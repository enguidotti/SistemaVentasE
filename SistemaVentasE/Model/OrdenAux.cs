using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasE.Model
{
    public class OrdenAux
    {
        public int numFactura { get; set; }
        public string local { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
        public int codigo { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public int precioCompra { get; set; }
        public int totalProducto { get; set; }
        public int totalFactura { get; set; }

    }
}
