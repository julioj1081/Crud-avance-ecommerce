using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using BL;
namespace PL_Consola
{
    class Area
    {
        public static void Add()
        {
            ML.Area area = new ML.Area();
            Console.WriteLine("Ingrese el Nombre del area");
            area.Nombre = Console.ReadLine();
            //Se va a BL
            ML.Result result = BL.Area.AddArea(area);
            if (result.Correct)
            {
                Console.WriteLine("Area insertado correctamente");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Area area = new ML.Area();
            Console.WriteLine("Ingresa el id del area");
            area.IdArea = int.Parse(Console.ReadLine());
            ML.Result result = BL.Area.DeleteArea(area);
            if (result.Correct)
            {
                Console.WriteLine("Area eliminado correctamente");
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
                ML.Area area = new ML.Area();
                Console.WriteLine("Ingresa id del area");
                area.IdArea = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Ingresa Nombre de la nueva area");
                area.Nombre = Console.ReadLine();
                //Se va al BL
                ML.Result res = BL.Area.UpdateArea(area);
                if (res.Correct)
                {
                    Console.WriteLine("Area modificada");
                }
                else
                {
                    Console.WriteLine("Area no se pudo modificar");
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "No se pudo modificar" + e;
            }
        }
    
        public static void GetAll()
        {
            Console.WriteLine("Tabla Area");
            ML.Result result = BL.Area.GetAllArea();
            if (result.Correct)
            {
                foreach(ML.Area area in result.Objects)
                {
                    Console.WriteLine("IdArea: " + area.IdArea + " Area:" + area.Nombre);
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
