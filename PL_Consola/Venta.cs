using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    class Venta
    {

        public static void Add()
        {
            ML.Venta venta = new ML.Venta();
            Console.WriteLine("Selecciona el ID del Cliente");
            venta.IdCliente = int.Parse(Console.ReadLine());
            //Preguntar si es que se debe de tomar de cantidad * precio de cada producto de ventaproducto
            //para que se agrege al total
            Console.WriteLine("Total || cantidad pago?");
            venta.Total = float.Parse(Console.ReadLine());
            //
            Console.WriteLine("Ingresa el Id de Metodo del pago");
            venta.IdMetodoPago = int.Parse(Console.ReadLine());
            DateTime fecha = DateTime.Now;
            Console.WriteLine("Se realizo la venta el dia: "+fecha);
            venta.Fecha = fecha;

            //Se va al BL
            ML.Result result = BL.Venta.AddVenta(venta);
            if (result.Correct)
            {
                Console.WriteLine("Se realizo la venta");
            }
            else
            {
                Console.WriteLine("No se realizo la venta " + result.ErrorMessage);
            }
        }
    
        public static void Delete()
        {
            ML.Venta venta = new ML.Venta();
            Console.WriteLine("Ingresa el Id de venta a eliminar");
            venta.IdVenta = int.Parse(Console.ReadLine());
            ML.Result result = BL.Venta.DeleteVenta(venta);
            if (result.Correct)
            {
                Console.WriteLine("Venta eliminada");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetAll()
        {
            Console.WriteLine("Tabla Venta");
            ML.Result result = BL.Venta.GetAllVenta();
            if (result.Correct)
            {
                foreach (ML.Venta venta in result.Objects)
                {
                    Console.WriteLine("IdVenta: " + venta.IdVenta + " Cliente:" + venta.Cliente + " Total: "+ venta.Total + " Metodo pago: "+ venta.MetodoPago + " "+ venta.Fecha);
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
