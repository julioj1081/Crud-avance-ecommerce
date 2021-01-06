using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProducto
    {
        [OperationContract]
        Result2 AddProducto(ML.Producto producto);

        [OperationContract]
        Result2 DeleteProducto(ML.Producto producto);

        [OperationContract]
        Result2 UpdateProducto(ML.Producto producto);
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Result2
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        public Exception Ex { get; set; }
    }
}
