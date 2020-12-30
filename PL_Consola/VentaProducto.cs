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
            ventaProducto.IdVenta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el Id de producto Sucursal");
            ventaProducto.IdProductoSucursal = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa cantidad");
            ventaProducto.Cantidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el Id del Producto");
            ventaProducto.IdProducto = int.Parse(Console.ReadLine());
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

    }
}
