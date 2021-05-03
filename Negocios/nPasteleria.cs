using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
    public class nPasteleria
    {
        dPasteleria datospas;
        public nPasteleria()
        {
            datospas = new dPasteleria();
        }
        public string RegistrarPasteleria(string idcliente,int idplatos)
        {
            ePasteleria pasteleria = new ePasteleria()
            {
                dniCliente = idcliente,
                idplatos = idplatos
            };
            return datospas.Insertar(pasteleria);
        }
        public string ModificarPasteleria(int idpasteleria,int idplato,string idcliente)
        {
            ePasteleria pasteleria = new ePasteleria()
            {
                dniCliente = idcliente,
                idplatos = idplato,
            };
            return datospas.Modificar(pasteleria,idpasteleria);
        }
        public string Eliminarpasteleria(int id)
        {
            return datospas.Eliminar(id);
        }
        public List<ePasteleria> listarpasteleria()
        {
            return datospas.listodo();
        }
    }
}
