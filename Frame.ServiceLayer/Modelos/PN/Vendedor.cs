using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Vendedores
    {
        public Vendedor[] value { get; set; }
    }
    public class Vendedor
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
