using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Projetos
    {
        public Projeto[] value { get; set; }
    }
    public class Projeto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
