using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Paises
    {
        public Pais[] value { get; set; }
    }
    public class Pais
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
