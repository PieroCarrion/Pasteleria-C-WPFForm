﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCliente
    {
        public string DNI { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
