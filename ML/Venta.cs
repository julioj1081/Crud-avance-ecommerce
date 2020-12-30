using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Venta
    {
        public int IdVenta{get;set;}
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public float Total { get; set; }
        public int IdMetodoPago { get; set; }
        public string MetodoPago { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public List<object> Ventas { get; set; }
    }
}
