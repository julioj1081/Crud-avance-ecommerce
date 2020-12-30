using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class MetodoPago
    {
        public static void Add()
        {
            ML.MetodoPago metodopago = new ML.MetodoPago();
            Console.WriteLine("Ingrese el Nombre del metodo pago");
            metodopago.Metodo = Console.ReadLine();
            //Se va a BL
            ML.Result result = BL.MetodoPago.AddMetodo(metodopago);
            if (result.Correct)
            {
                Console.WriteLine("Metodo pago insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.MetodoPago metodopago = new ML.MetodoPago();
            Console.WriteLine("Ingresa el id del metodo pago");
            metodopago.IdMetodoPago = int.Parse(Console.ReadLine());
            ML.Result result = BL.MetodoPago.DeleteMetodoPago(metodopago);
            if (result.Correct)
            {
                Console.WriteLine("Metodo de pago eliminado");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.Result res = new ML.Result();
            try
            {
                ML.MetodoPago metodoPago = new ML.MetodoPago();
                //
                Console.WriteLine("Ingresa el Id Del metodo de pago");
                metodoPago.IdMetodoPago = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa Nombre del Metodo de pago");
                metodoPago.Metodo = Console.ReadLine();
                //Se a al BL
                ML.Result result = BL.MetodoPago.UpdateMetodoPago(metodoPago);

                if (result.Correct)
                {
                    Console.WriteLine("Metodo de pago a sido cambiado");
                }
                else
                {
                    result.Correct = false;
                    Console.WriteLine(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                res.Correct = false;
                res.ErrorMessage = "Error desconocido" + e;
            }
        }
    
        public static void GetAll()
        {
            Console.WriteLine("Tabla Metodo Pago");
            ML.Result result = BL.MetodoPago.GetAllMetodoPago();
            if (result.Correct)
            {
                foreach(ML.MetodoPago metodo in result.Objects)
                {
                    Console.WriteLine("IdMetodoPago: "+metodo.IdMetodoPago + " Metodo: "+metodo.Metodo);
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
