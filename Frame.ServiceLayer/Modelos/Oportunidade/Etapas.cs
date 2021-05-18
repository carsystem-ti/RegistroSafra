using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Oportunidade
{
    public class Etapas
    {
        public Etapa[] value { get; set; }
    }
    public class Etapa
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
