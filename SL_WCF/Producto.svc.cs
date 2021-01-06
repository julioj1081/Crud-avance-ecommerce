using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Producto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Producto.svc o Producto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Producto : IProducto
    {
        public Result2 AddProducto(ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddProducto(producto);
            //SL_WCF.Result2 resultSL = new Result2();
            //resultSL.Correct = result.Correct;
            //resultSL.ErrorMessage = result.ErrorMessage;
            //resultSL.Ex = result.Ex;
           
            return new Result2 { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result2 DeleteProducto(ML.Producto producto)
        {
            ML.Result result = BL.Producto.DeleteProducto(producto);
            //SL_WCF.Result2 resultSL = new Result2();
            //resultSL.Correct = result.Correct;
            //resultSL.ErrorMessage = result.ErrorMessage;
            //resultSL.Ex = result.Ex;
            
            return new Result2 { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result2 UpdateProducto(ML.Producto producto)
        {
            ML.Result result = BL.Producto.UpdateProducto(producto);
            return new Result2 { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
    }
}
