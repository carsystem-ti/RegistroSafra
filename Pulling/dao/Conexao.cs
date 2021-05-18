using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulling.dao
{
    public class Conexao
    {
        public string user { get; set; }
        public string senha { get; set; }
        public string banco { get; set; }
        public string UrlServiceLayer { get; set; }
    }
}
