//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Entities
//{
//    internal class Usuario
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario //objeto usuario
    {
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public int Password { get; set; }
    }
}
