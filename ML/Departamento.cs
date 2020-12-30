using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string NombreD { get; set; }
        public int IdArea { get; set; }
        public string Are { get; set; }
        public List<object> Departamentos { get; set; }
        //public ML.Area Area { get; set; }
    }
}
