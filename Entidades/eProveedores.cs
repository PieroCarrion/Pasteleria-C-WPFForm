using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eProveedores
    {
        public int idCompania { get; set; }
        public string Nombreproducto { get; set; }
        public string NombreEmpresa { get; set; }
        public override string ToString()
        {
            return Nombreproducto;
        }
    }
}
