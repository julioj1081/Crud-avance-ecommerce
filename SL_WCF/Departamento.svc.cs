using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Departamento" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Departamento.svc o Departamento.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Departamento : IDepartamento
    {
        
        //Depto , Producto
        public Result AddDepartamento(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddDepartamento(departamento);

            //SL_WCF.Result resultSL = new Result();
            //resultSL.Correct = result.Correct;
            //resultSL.ErrorMessage = result.ErrorMessage;
            //resultSL.Ex = result.Ex;

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }
        public Result DeleteDepartamento(int departamento)
        {
            ML.Result result = BL.Departamento.DeleteDepartamento(departamento);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result UpdateDepartamento(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.UpdateDepartamento(departamento);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        //public Result GetAllDepartamento()
        //{
        //    ML.Result result = BL.Departamento.GetAllDepartamento();
        //    return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Objects = result.Objects};
        //}
    }
}
