using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Grupos
    {
        public Grupo[] value { get; set; }
    }
    public class Grupo
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
