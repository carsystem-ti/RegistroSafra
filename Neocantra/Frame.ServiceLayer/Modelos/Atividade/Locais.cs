using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Locais
    {
        public Local[] value { get; set; }
    }
    public class Local
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
