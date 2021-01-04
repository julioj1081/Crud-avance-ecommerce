﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class VentaProducto
    {
        public int IdVentaProducto { get; set; }
        //public int IdVenta { get; set; }
        //public string Venta { get; set; }
        public ML.Venta Venta { get; set; }
        //public int IdProductoSucursal { get; set; }
        //public string ProductoSucursal { get; set; }
        public ML.ProductoSucursal ProductoSucursal { get; set; }
        public ML.Sucursal Sucursal { get; set; }

        public int Cantidad { get; set; }
        //public int IdProducto { get; set; }
        //public string Producto { get; set; }
        public ML.Producto Producto { get; set; }

        public List<object> VentaProductos { get; set; }
    }
}
