using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class Proveedor
    {
        public static void Add()
        {
            ML.Proveedor proveedor = new ML.Proveedor();
            Console.WriteLine("Ingresa Nombre del proveedor");
            proveedor.NombreProvedor = Console.ReadLine();
            Console.WriteLine("Ingresa telefono del proveedor");
            proveedor.Telefono = Console.ReadLine();
            //Se va al BL
            ML.Result result = BL.Proveedor.AddProveedor(proveedor);
            //
            if (result.Correct)
            {
                Console.WriteLine("Proveedor insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Proveedor proveedor = new ML.Proveedor();
            Console.WriteLine("Ingresa el id del proveedor");
            proveedor.IdProveedor = int.Parse(Console.ReadLine());
            ML.Result result = BL.Proveedor.DeleteProveedor(proveedor);
            if (result.Correct)
            {
                Console.WriteLine("Proveedor eliminado correctamente");
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
                ML.Proveedor proveedor= new ML.Proveedor();
                Console.WriteLine("Ingresa id del proveedor");
                proveedor.IdProveedor = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa Nombre del nuevo proveedor");
                proveedor.NombreProvedor = Console.ReadLine();
                Console.WriteLine("Ingresa el telefono nuevo del proveedor");
                proveedor.Telefono = Console.ReadLine();
                //Se va al BL
                ML.Result res = BL.Proveedor.UpdateProveedor(proveedor);
                if (res.Correct)
                {
                    Console.WriteLine("Proveedor modificado");
                }
                else
                {
                    Console.WriteLine("El proveedor no se pudo modificar");
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
            Console.WriteLine("Tabla Proveedor");
            ML.Result result = BL.Proveedor.GetAllProveedor();
            if (result.Correct)
            {
                foreach (ML.Proveedor proveedor in result.Objects)
                {
                    Console.WriteLine("IdProveedor: " + proveedor.IdProveedor+ " Nombre:" + proveedor.NombreProvedor + " Telefono "+proveedor.Telefono);
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
