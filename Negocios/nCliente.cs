using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
   public class nCliente
    {
        dCliente datos;
        public nCliente()
        {
            datos = new dCliente();
        }
        public string RegistrarCliente(string DNI, string nombre, string clave)
        {
            eCliente cliente = new eCliente()
            {
                DNI = DNI,
                clave = clave,
                nombre = nombre
            };
            return datos.Insertar(cliente);
        }
        public string ActuzalizarCliente(string contraseña, string nombre , string DNIaModificar)
        {
            eCliente cliente = new eCliente()
            {
                nombre = nombre,
                clave = contraseña
            };
            return datos.Modificar(cliente,DNIaModificar);
        }
        public string EliminarCliente(string id)
        {
            return datos.Eliminar(id);
        }
        public List<eCliente> listarclientes()
        {
            return datos.lisarTodo();
        }
    }
}
