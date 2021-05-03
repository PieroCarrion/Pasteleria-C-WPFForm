using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eProducto
    {
        public int idProducto { get; set; }
        public string idCompania { get; set; }
        public string idPlato { get; set; } 
        public int cantidad { get; set; }
        public override string ToString()
        {
            return cantidad.ToString();
        }
    }
}
