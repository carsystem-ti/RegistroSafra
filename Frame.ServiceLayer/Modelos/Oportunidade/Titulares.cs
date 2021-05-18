using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Oportunidade
{
    public class Titulares
    {
        public Titular[] value { get; set; }
    }
    public class Titular
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
