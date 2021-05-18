using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class UsoPrincipais
    {
        public UsoPrincipal[] value { get; set; }
    }
    public class UsoPrincipal
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
