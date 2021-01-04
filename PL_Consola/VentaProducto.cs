using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    class VentaProducto
    {
        public static void Add()
        {
            ML.VentaProducto ventaProducto= new ML.VentaProducto();
            Console.WriteLine("Ingrese el Id de venta");
            ventaProducto.Venta= new ML.Venta();
            ventaProducto.Venta.IdVenta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el Id de producto Sucursal");
            ventaProducto.ProductoSucursal = new ML.ProductoSucursal();
            ventaProducto.ProductoSucursal.IdProductoSucursal= int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa cantidad");
            ventaProducto.Cantidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el Id del Producto");
            ventaProducto.Producto = new ML.Producto();
            ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());
            //Se va a BL
            ML.Result result = BL.VentaProducto.AddVentaProducto(ventaProducto);
            if (result.Correct)
            {
                Console.WriteLine("VentaProducto se insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
        public static void GetAll()
        {
            ML.Result result = BL.VentaProducto.GetAllVentaProducto();
            if (result.Correct)
            {
                foreach (ML.VentaProducto VentaProducto in result.Objects)
                {
                    Console.WriteLine("IdVentaProducto: " + VentaProducto.IdVentaProducto + " IdVenta:" + VentaProducto.Venta + " IdProductoSucursal: " + VentaProducto.ProductoSucursal + " Cantidad: " + VentaProducto.Cantidad + " Id Producto: " + VentaProducto.Producto);
                }
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error";
            }
        }

    }
}
