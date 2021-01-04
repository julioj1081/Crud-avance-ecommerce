using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class Sucursal
    {
        public static void Add()
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            Console.WriteLine("Ingrese el Nombre de la sucursal");
            sucursal.Nombre = Console.ReadLine();
            //Se va a BL
            ML.Result result = BL.Sucursal.AddSucursal(sucursal);
            if (result.Correct)
            {
                Console.WriteLine("Sucursal insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            Console.WriteLine("Ingresa el id de la sucursa");
            sucursal.IdSucursal = int.Parse(Console.ReadLine());
            ML.Result result = BL.Sucursal.DeleteSucursal(sucursal);
            if (result.Correct)
            {
                Console.WriteLine("Sucursal eliminada correctamente");
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
                ML.Sucursal sucursal = new ML.Sucursal();
                Console.WriteLine("Ingresa id de la sucursal");
                sucursal.IdSucursal = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa Nombre de la nueva sucursal");
                sucursal.Nombre = Console.ReadLine();
                //Se va al BL
                ML.Result res = BL.Sucursal.UpdateSucursal(sucursal);
                if (res.Correct)
                {
                    Console.WriteLine("Sucursal ha sido modificada");
                }
                else
                {
                    Console.WriteLine("La Sucursal no se pudo modificar");
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
            Console.WriteLine("Tabla Sucursal");
            ML.Result result = BL.Sucursal.GetAllSucursal();
            if (result.Correct)
            {
                foreach (ML.Sucursal sucursal in result.Objects)
                {
                    Console.WriteLine("IdSucursal: " + sucursal.IdSucursal + " Nombre:" + sucursal.Nombre);
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
