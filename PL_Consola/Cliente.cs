using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    class Cliente
    {
        public static void Add()
        {
            ML.Cliente cliente = new ML.Cliente();
            Console.WriteLine("Ingrese el Nombre del cliente");
            cliente.NombreC = Console.ReadLine();
            Console.WriteLine("Ingresa RFC del cliente");
            cliente.Rfc = Console.ReadLine();
            //Se va a BL
            ML.Result result = BL.Cliente.AddCliente(cliente);
            if (result.Correct)
            {
                Console.WriteLine("Cliente insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Cliente cliente = new ML.Cliente();
            Console.WriteLine("Ingresa el id del cliente");
            cliente.IdCliente = int.Parse(Console.ReadLine());
            ML.Result result = BL.Cliente.DeleteCliente(cliente);
            if (result.Correct)
            {
                Console.WriteLine("Cliente eliminado correctamente");
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
                ML.Cliente cliente = new ML.Cliente();
                Console.WriteLine("Ingresa id del cliente");
                cliente.IdCliente = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa el nuevo Nombre del cliente");
                cliente.NombreC = Console.ReadLine();
                Console.WriteLine("Ingresa el nuevo RFC del cliente");
                cliente.Rfc = Console.ReadLine();
                //Se va al BL
                ML.Result res = BL.Cliente.UpdateCliente(cliente);
                if (res.Correct)
                {
                    Console.WriteLine("Cliente a sido modificada");
                }
                else
                {
                    Console.WriteLine("Cliente no se pudo modificar");
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
            Console.WriteLine("Tabla Cliente");
            ML.Result result = BL.Cliente.GetAllCliente();
            if (result.Correct)
            {
                foreach (ML.Cliente cliente in result.Objects)
                {
                    Console.WriteLine("IdCliente: " + cliente.IdCliente + " Nombre:" + cliente.NombreC + " RFC:" + cliente.Rfc);
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
