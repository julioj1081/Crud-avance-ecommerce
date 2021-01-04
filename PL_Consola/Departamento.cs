using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Consola
{
    public class Departamento
    {
        public static void Add()
        {
            ML.Departamento departamento = new ML.Departamento();
            Console.WriteLine("Ingresa Nombre Departamento");
            departamento.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa Id Del area");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());
            //Se va al BL
            ML.Result result = BL.Departamento.AddDepartamento(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Departamento Insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
            
        }

        public static void Delete()
        {
            ML.Departamento departamento = new ML.Departamento();
            Console.WriteLine("Ingresa el id del departamento");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());
            ML.Result result = BL.Departamento.DeleteDepartamento(departamento);
            if (result.Correct)
            {
                Console.WriteLine("Departamento eliminado correctamente");
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
                ML.Departamento departamento = new ML.Departamento();
                Console.WriteLine("Ingresa id del departamento");
                departamento.IdDepartamento = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa Nombre del nuevo departamento");
                departamento.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa el Id Del Area");
                departamento.Area = new ML.Area();
                departamento.Area.IdArea = int.Parse(Console.ReadLine());
                //Se va al BL
                ML.Result res = BL.Departamento.UpdateDepartamento(departamento);
                if (res.Correct)
                {
                    Console.WriteLine("Departamento modificado");
                }
                else
                {
                    Console.WriteLine("El Departamento no se pudo modificar");
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
            Console.WriteLine("Tabla Departamento");
            ML.Result result = BL.Departamento.GetAllDepartamento();
            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento + " Departamento:" + departamento.Nombre + " Area: "+departamento.Area.Nombre);
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
