using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Itens
    {
        public Iten[] value { get; set; }
    }
    public class Iten
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
