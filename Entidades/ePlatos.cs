using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ePlatos
    {
        public int idPlatos { get; set; }
        public string postre  { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public override string ToString()
        {
            return postre + " " ;
        }
    }
}
