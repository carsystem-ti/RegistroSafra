using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Utilizacoes
    {
        public Utilizacao[] value { get; set; }
    }
    public class Utilizacao
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
