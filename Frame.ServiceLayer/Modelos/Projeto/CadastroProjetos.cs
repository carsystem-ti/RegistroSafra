using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Projeto
{
    public class CadastroProjetos
    {
        public string odatametadata { get; set; }
        public CadastroProjeto[] value { get; set; }
    }

    public class CadastroProjeto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string Active { get; set; }
    }

}
