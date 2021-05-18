using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Filiais
    {
        public Filial[] value { get; set; }
    }
    public class Filial
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
