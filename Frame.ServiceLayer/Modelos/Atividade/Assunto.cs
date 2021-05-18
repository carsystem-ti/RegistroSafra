using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Assuntos
    {
        public Assunto[] value { get; set; }
    }
    public class Assunto
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
