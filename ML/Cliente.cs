using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreC { get; set; }
        public string Rfc { get; set; }

        public List<object> Clientes { get; set; }
    }
}
