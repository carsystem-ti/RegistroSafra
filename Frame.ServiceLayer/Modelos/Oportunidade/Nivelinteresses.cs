using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Oportunidade
{
    public class Nivelinteresses
    {
        public Nivelinteresse[] value { get; set; }
    }
    public class Nivelinteresse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
