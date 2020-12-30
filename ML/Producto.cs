using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public string Image { get; set; }
    }
}
