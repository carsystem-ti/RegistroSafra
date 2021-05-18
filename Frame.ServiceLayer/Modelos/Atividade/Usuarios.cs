using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Usuarios
    {
        public Usuario[] value { get; set; }
    }
    public class Usuario
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
