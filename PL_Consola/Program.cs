using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("1 Area");
                Console.WriteLine("2 Departamento");
                Console.WriteLine("3 Proveedor");
                Console.WriteLine("4 Producto");
                Console.WriteLine("5 Sucursal");
                Console.WriteLine("6 Producto Sucursal");
                Console.WriteLine("7 MetodoPago");
                Console.WriteLine("8 Cliente");
                Console.WriteLine("9 Venta");
                Console.WriteLine("10 VentaProducto");
                int caso = int.Parse(Console.ReadLine());
                switch (caso)
                {
                    case 1:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        int opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Area.Add();
                                break;
                            case 2:
                                PL_Consola.Area.Delete();
                                break;
                            case 3:
                                PL_Consola.Area.Update();
                                break;
                            case 4:
                                PL_Consola.Area.GetAll();
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Departamento.Add();
                                break;
                            case 2:
                                PL_Consola.Departamento.Delete();
                                break;
                            case 3:
                                PL_Consola.Departamento.Update();
                                break;
                            case 4:
                                PL_Consola.Departamento.GetAll();
                                break;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Proveedor.Add();
                                break;
                            case 2:
                                PL_Consola.Proveedor.Delete();
                                break;
                            case 3:
                                PL_Consola.Proveedor.Update();
                                break;
                            case 4:
                                PL_Consola.Proveedor.GetAll();
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Producto.Add();
                                break;
                            case 2:
                                PL_Consola.Producto.Delete();
                                break;
                            case 3:
                                PL_Consola.Producto.Update();
                                break;
                            case 4:
                                PL_Consola.Producto.GetAll();
                                break;
                        }
                        break;

                    case 5:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Sucursal.Add();
                                break;
                            case 2:
                                PL_Consola.Sucursal.Delete();
                                break;
                            case 3:
                                PL_Consola.Sucursal.Update();
                                break;
                            case 4:
                                PL_Consola.Sucursal.GetAll();
                                break;
                        }
                        break;

                    case 6:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.ProductoSucursal.Add();
                                break;
                            case 2:
                                PL_Consola.ProductoSucursal.Delete();
                                break;
                            case 3:
                                PL_Consola.ProductoSucursal.Update();
                                break;
                            case 4:
                                PL_Consola.ProductoSucursal.GetAll();
                                break;
                        }
                        break;

                    case 7:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.MetodoPago.Add();
                                break;
                            case 2:
                                PL_Consola.MetodoPago.Delete();
                                break;
                            case 3:
                                PL_Consola.MetodoPago.Update();
                                break;
                            case 4:
                                PL_Consola.MetodoPago.GetAll();
                                break;
                        }
                        break;
                    case 8:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Modificar 3");
                        Console.WriteLine("Mostrar 4");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Cliente.Add();
                                break;
                            case 2:
                                PL_Consola.Cliente.Delete();
                                break;
                            case 3:
                                PL_Consola.Cliente.Update();
                                break;
                            case 4:
                                PL_Consola.Cliente.GetAll();
                                break;
                        }
                        break;
                    case 9:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Eliminar 2");
                        Console.WriteLine("Mostrar 3");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.Venta.Add();
                                break;
                            case 2:
                                PL_Consola.Venta.Delete();
                                break;
                            case 3:
                                PL_Consola.Venta.GetAll();
                                break;
                        }
                        break;
                    case 10:
                        Console.WriteLine("Insertar 1");
                        Console.WriteLine("Mostrar 2");
                        opcion = int.Parse(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                PL_Consola.VentaProducto.Add();
                                break;
                            case 2:
                                PL_Consola.VentaProducto.GetAll();
                                break;
                        }
                        break;


                }
            }
            catch(Exception e)
            {
                throw e;
            }
            Console.ReadKey();
        }
    }
}
