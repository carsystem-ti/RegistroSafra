using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Oportunidade
{
    public class Descricoes
    {
        public Descricao[] value { get; set; }
    }
    public class Descricao
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
