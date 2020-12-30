using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class Producto
    {
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingresa Nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa Descripcion del producto");
            producto.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingresa precio del producto");
            producto.Precio = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el IdDepartamento");
            producto.IdDepartamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el IdProveedor");
            producto.IdProveedor = int.Parse(Console.ReadLine());
            //imagen null
            
            producto.Image = "No disponible";

            //Se va a BL
            ML.Result result = BL.Producto.AddProducto(producto);
            if (result.Correct)
            {
                Console.WriteLine("Producto insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingresa el id del producto");
            producto.IdProducto = int.Parse(Console.ReadLine());
            ML.Result result = BL.Producto.DeleteProducto(producto);
            if (result.Correct)
            {
                Console.WriteLine("Producto eliminado correctamente");
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
                ML.Producto producto = new ML.Producto();
                Console.WriteLine("Ingresa id del producto");
                producto.IdProducto = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa Nombre del nuevo producto");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa Descripcion del producto");
                producto.Descripcion = Console.ReadLine();
                Console.WriteLine("Ingresa precio del producto");
                producto.Precio = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa IdDepartamento");
                producto.IdDepartamento = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa IdProveedor");
                producto.IdProveedor = int.Parse(Console.ReadLine());

                producto.Image = "No disponible";

                //Se va a BL
                ML.Result res = BL.Producto.UpdateProducto(producto);
                if (res.Correct)
                {
                    Console.WriteLine("Producto modificado correctamente");
                }
                else
                {
                    Console.WriteLine(res.ErrorMessage);
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
            Console.WriteLine("Tabla Productos");
            ML.Result result = BL.Producto.GetAllProducto();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto + " Nombre:" + producto.Nombre + " Descripcion: "+producto.Descripcion+ " Precio: "+producto.Precio+ " Departamento: "+producto.Departamento+ " Proveedor:"+producto.Proveedor+ " Image: "+producto.Image);
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
