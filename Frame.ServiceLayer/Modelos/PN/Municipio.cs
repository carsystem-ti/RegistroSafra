using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Municipios
    {
        public Municipio[] value { get; set; }
    }
    public class Municipio
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
