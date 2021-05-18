using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Tipos
    {
        public Tipo[] value { get; set; }
    }
    public class Tipo
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
