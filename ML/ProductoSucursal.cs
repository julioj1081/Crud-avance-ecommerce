using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ProductoSucursal
    {
        public int IdProductoSucursal { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
    }
}
