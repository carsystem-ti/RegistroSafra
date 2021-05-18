using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Estados
    {
        public Estado[] value { get; set; }
    }
    public class Estado
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
