using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Series
    {
        public Serie[] value { get; set; }
    }
    public class Serie
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
