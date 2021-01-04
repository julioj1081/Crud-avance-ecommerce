using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class ProductoSucursal
    {
        public static void Add()
        {
            ML.ProductoSucursal productosucursal = new ML.ProductoSucursal();
            Console.WriteLine("Ingresa el IdProducto");
            productosucursal.Producto = new ML.Producto();
            productosucursal.Producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el IdSucursal");
            productosucursal.Sucursal = new ML.Sucursal();
            productosucursal.Sucursal.IdSucursal = int.Parse(Console.ReadLine());
            //Se va a BL
            ML.Result result = BL.ProductoSucursal.AddProductoSucursal(productosucursal);
            if (result.Correct)
            {
                Console.WriteLine("Producto_Sucursal insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.ProductoSucursal productosucursal = new ML.ProductoSucursal();
            Console.WriteLine("Ingresa el id producto_sucursal");
            productosucursal.IdProductoSucursal = int.Parse(Console.ReadLine());
            ML.Result result = BL.ProductoSucursal.DeleteProductoSucursal(productosucursal);
            if (result.Correct)
            {
                Console.WriteLine("Producto_sucursal eliminado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.Result result = new ML.Result();
            try
            {
                ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
                Console.WriteLine("Ingresa id del producto_sucursal");
                productoSucursal.IdProductoSucursal = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa IdProducto nuevo");
                productoSucursal.Producto = new ML.Producto();
                productoSucursal.Producto.IdProducto = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa IdSucursal nuevo");
                productoSucursal.Sucursal = new ML.Sucursal();
                productoSucursal.Sucursal.IdSucursal = int.Parse(Console.ReadLine());
                //Se va al BL
                ML.Result res = BL.ProductoSucursal.UpdateProductoSucursal(productoSucursal);
                if (res.Correct)
                {
                    Console.WriteLine("ProductoSucursal ha sido modificado");
                }
                else
                {
                    Console.WriteLine("ProductoSucursal no se pudo modificar");
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "No se pudo modificar" + e;
            }
        }

        public static void GetAll()
        {
            Console.WriteLine("Tabla ProductoSucursal");
            ML.Result result = BL.ProductoSucursal.GetAllProductoSucursal();
            if (result.Correct)
            {
                foreach (ML.ProductoSucursal productoSucursal in result.Objects)
                {
                    Console.WriteLine("IdProductoSucursal: " + productoSucursal.IdProductoSucursal + " Producto:" + productoSucursal.Producto.Nombre+ " Sucursal:"+productoSucursal.Sucursal.Nombre);
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
