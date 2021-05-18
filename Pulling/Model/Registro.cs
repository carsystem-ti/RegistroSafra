using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulling.Model
{
    public class Registro
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public int numero { get; set; }
        public int numeroCliente { get; set; }
        public string codigoBarras { get; set; }
        public string indicadorBaseCentral { get; set; }
    }

}